using System.Numerics;
using System.Xml.Linq;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Goal : MonoBehaviour
{
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
        col.enabled = true;
        GameManager.Instance.StageLoad(GameManager.Instance.stage);
        
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R))
        { //R 눌렀을 때 스테이지 로드 호출
            GameManager.Instance.StageLoad(GameManager.Instance.stage);
        }
}
    

    
    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 충돌 했을 때
    {
        if(collision.gameObject.name == "Player")
        {
            GameManager.Instance.StageClear(GameManager.Instance.stage);
        }
        
    }
}
