using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //인게임 변수 =========================================================
    public string[] BGcolor_list = {"gray", "red", "green", "blue"};
    public string BGcolor;
    public int stage = 1; //현재 스테이지
    public string isDrag = ""; //박스(이외 다양한거) 끄는 거
    public bool isClimb = false; //사다리 판단
    public bool isClimbing = false; //사다리 타고있는지 판단
    public bool isKey = false; //열쇠 먹었는지
    public bool isBox = false; //상자발판 실행 여부
    public bool player_right; //Player가 오른쪽을 보고 있는지
    public bool isLocked = true;
            

    //UI 변수 ============================================================
    public bool isGameStart = false;
    public bool isInGame = false;
    public bool isGameEnd = false;
    public bool isMainMenu = false;
    public string[] colorOnMouse_list = {"gray", "red", "green", "blue"};
    public string colorOnMouse;
    public bool isClick = false;


    //스테이지 로드용 변수
    public GameObject Box1;
    public GameObject Box3;
    public Transform player;
    public Transform BG;
    public GameObject cam;
    public Transform goal;
    public Transform mousepointer;


    //싱글톤 선언 =========================================================
    public static GameManager Instance { get; private set;}
    private void Awake()
    {
        //커서 안보이게 할까 보이게 할까
        UnityEngine.Cursor.visible = false;
        Box1.SetActive(false);
        Box3.SetActive(false);


        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        
        BGcolor = BGcolor_list[0];
        StageLoad(stage);
    }
    //=====================================================================

    private void Update()
    {
        //if (isGameStart)
        //{
        //    CutScene();
        //}

        //if (isInGame)
        //{
            AbleCollidersWithTag(BGcolor_list, BGcolor);
        //}
        
    }

    //tag에 따라서 collider 없애주는 함수 ===================================

    //선택된 tag 아닌 것들 collider 다시 생성해주는 함수
    void CutScene()
    {
        isGameStart = false;
        player.transform.position = new Vector3();
    }
    void AbleCollidersWithTag(Array tagL, string tag)
    {
        foreach (string a in tagL)
        {
            if (a == tag){
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

                foreach (GameObject obj in objectsWithTag)
                {
                    obj.GetComponent<SpriteRenderer>().enabled = false;
                    obj.GetComponent<Collider2D>().enabled = false;
                }
            }
            else {
                GameObject[] objectsWithTagN = GameObject.FindGameObjectsWithTag(a);

                foreach (GameObject obj in objectsWithTagN)
                {
                    obj.GetComponent<SpriteRenderer>().enabled = true;
                    obj.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
    }

    public void StageLoad(int stage)
    {
        Debug.Log($"---{stage}스테이지 로드---");
        if (stage == 1)
        {
            Box1.SetActive(true);
            Box3.SetActive(false);
            player.transform.position = new Vector2(-6, -22);
            BG.transform.position = new Vector2(0, -20);
            cam.transform.position = new Vector3(0, -20, -10);
            goal.transform.position = new Vector2(8.9f, -24.26f);
            mousepointer.transform.position = new Vector2(0f, -20f);
        }
        if (stage == 2)
        {
            Box1.SetActive(false);
            Box3.SetActive(true);
            BG.transform.position = new Vector2(17.3f, -20);
            goal.transform.position = new Vector2(24.5f, -20.8f);
            mousepointer.transform.position = new Vector2(20f, -20f);
        }
    }
    public void StageClear(int stage)
    {
        Debug.Log($"---{stage}스테이지 클리어---");
        GameManager.Instance.stage += 1;
        StageLoad(GameManager.Instance.stage);
        Debug.Log($"---{stage}스테이지 로드---");
        cam.GetComponent<CameraMove>().StageLoad();
    }
}
