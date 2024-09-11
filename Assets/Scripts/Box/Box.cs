using System.Numerics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Box : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask pLayer;
    public GameObject pl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.6f, pLayer))
        {
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FrontCheck")
        {
            //Debug.Log("박스 충돌");
            if (Input.GetKeyDown(KeyCode.F))
            { 
                Debug.Log(gameObject.name);
                //Debug.Log("밀기 전환");
                if (GameManager.Instance.isDrag == "")
                {
                    pl.GetComponent<Animator>().SetBool("isDrag", true);
                    if (GameManager.Instance.player_right)
                    {
                        GameManager.Instance.isDrag = "Right";
                    }
                    else
                    {
                        GameManager.Instance.isDrag = "Left";
                    }
                }
                else
                {
                    pl.GetComponent<Animator>().SetBool("isDrag", false);
                    GameManager.Instance.isDrag = "";
                }
            }
        }
    }
}
