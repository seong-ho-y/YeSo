using NUnit.Framework.Internal;
using System;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //플레이어 속도(횡이동, 종이동) 관련 변수들====================================================
    [SerializeField] float speed; //플레이어 속도 (웬만하면 이 변수로 속도 변경)
    public float inputValueX; //입력 받은 속도값 1 or -1 (횡이동 입력 받기 위해 만든 변수)
    public float inputValueY;


    
    //플레이어 점프 관련 변수들==================================================
    [SerializeField] float jumppower;
    public bool jumptrigger;
    public bool isJump;
    public bool isInAir;
    private float eventTime = 0.1f;
    private float startTime;
    public Transform groundCheckL;
    public Transform groundCheckR;
    public LayerMask groundLayer;
    public bool isClimb;

    //플레이어 파쿠르 관련 변수들=======================================================
    public bool parkour;
    public bool isParkouring;
    public Vector2 initialposition;
    public Transform wallCheck;
    public Transform wallCheckUnder;
    public float wallCheckRadius = 0.1f;
    private float climbSpeed = 200f;
    public Vector3 climbEndPosition;

    //그외 변수들========================================================================
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Collider2D col;
    private void Awake() //게임 시작 시 실행
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        
    }
    private void Start()
    {
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    private void Update() //1프레임당 1번 실행
    {
        //파쿠르 관련 로직
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Climb") && stateInfo.normalizedTime >= 0.8f && isParkouring)
        {
            Debug.Log("파쿠르 실행 완료");
            isParkouring = false;
            anim.ResetTrigger("isClimb");
            if (GameManager.Instance.player_right)
            { //파쿠르 위치 조정
                transform.position = transform.position + new Vector3(0.26f, 0.78f, 0f);
                //Debug.Log(climbEndPosition);
            }
            else
            {
                transform.position = transform.position + new Vector3(-0.26f, 0.78f, 0f);
            }
            parkour = false;
            rb.gravityScale = 1f;
            Debug.Log("파쿠르 도달");
        }

        //플레이어 이동속도 초기화
        if (GameManager.Instance.isDrag != "") //박스 끄는 상태일 때 속도 조정
        {
            speed = 0.7f;
        }
        else
        {
            speed = 1.2f; //기본 속도
        }

        //공중에 있는지 판단
        if (!Physics2D.OverlapCircle(groundCheckL.position, 0.01f, groundLayer) && !Physics2D.OverlapCircle(groundCheckR.position, 0.01f, groundLayer))
        {   //공중에 있을 때
            isInAir = true;
        }
        else
        { //땅에 있을 때
            isInAir = false;
            isClimb = false;
        }
        if (!Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer) && Physics2D.OverlapCircle(wallCheckUnder.position, 0.1f, groundLayer))
        {   //파쿠르 판단
            parkour = true;
            Debug.Log("파쿠르 상태");
        }
        else { parkour = false; }


        //파쿠르 애니메이션
        if (parkour && Input.GetKeyDown(KeyCode.Space) && (GameManager.Instance.isDrag == "")) //파쿠르 상태에서 점프를 눌렀을 때
        {
            initialposition = transform.position;
            anim.SetTrigger("isClimb");
            // 플레이어가 목표 위치에 도달했는지 확인
            isParkouring = true;
            rb.gravityScale = 0f;
        }
            
        if (isClimb) //줄 매달렸을 때 중력 없애기
        {
            rb.gravityScale = 0f;
        }
        else if(!isJump)
        {
            rb.gravityScale = 1f;
        }
        



        //플레이어 공중 제어
        if (isJump)
            { //점프를 했을 때
                jumptrigger = false;
                anim.SetBool("isGround", false);
                anim.SetBool("isJump", true);
                if (!isInAir && (Time.time - startTime >= eventTime))
                {
                    jumptrigger = true; //점프 초기화
                    anim.SetBool("isJump", false);
                    anim.SetBool("isGround", true);
                    isJump = false;
                }
            }
        else if (!isInAir) //플레이어가 땅에 있을 때
        {
            //Debug.Log("땅 판정");
            jumptrigger = true; //점프 초기화
            anim.SetBool("isGround", true);
            isJump = false;
        }
        else
        {
            jumptrigger = false;
            anim.SetBool("isGround", false);
        }

        if (speed > 0.6f && inputValueX != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }
    //==============================  <<<   Fixed Update   >>>  =============================================
    private void FixedUpdate() //1물리프레임당 1번 실행
    {
        if (isParkouring) //파쿠르 상태일 때 이동로직 잠그기
        {
            transform.position = initialposition;
            Debug.Log(initialposition);
        }
        else if (!isInAir) {
            col.isTrigger = false;
            rb.velocityX = inputValueX * speed; //x축 이동
            if (inputValueX > 0 && GameManager.Instance.isDrag == "") { //Player 이동방향 바라보기
                transform.localScale = new Vector3(0.5f, 0.5f, transform.localScale.z); //방향 설정
                GameManager.Instance.player_right = true;
            }
            else if (inputValueX < 0 && GameManager.Instance.isDrag == "") {
                transform.localScale = new Vector3(-0.5f, 0.5f, transform.localScale.z);
                GameManager.Instance.player_right = false;
            }
        }
        else if (isClimb)
        {
            col.isTrigger = true;
            rb.velocityX = 0;
            rb.velocityY = inputValueY * 1f;
        }
        else if (isInAir && !isJump){ //공중에 있을 때 이동속도 제어
            col.isTrigger = false;
            if (GameManager.Instance.player_right){ //공중에서 바라보는 방향으로 계속 이동
                rb.velocityX = 0.6f;
            }
            else{
                rb.velocityX = -0.6f;
            }
            isJump = false;
        }

    }


    private void OnMove(InputValue value) //x축 이동 입력받기
    {
        inputValueX = value.Get<Vector2>().x; //x축 입력받기
        inputValueY = value.Get<Vector2>().y;
    }

    private void OnJump() //점프 입력받기
    {
        if(jumptrigger && (GameManager.Instance.isDrag == "")){
            jumptrigger = false;
            rb.AddForceY(jumppower, ForceMode2D.Impulse);
            isJump = true;
            startTime = Time.time; //점프 할 때 시간 측정 (점프 후 GroundCheck가 땅에서 벗어날 때까지 시간)
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == LayerMask.NameToLayer("Rope")) && Input.GetKey(KeyCode.W))
        {
            isClimb = true;
            Debug.Log("Climb");
        }
    }
}