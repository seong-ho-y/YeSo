using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Collider2D col;
    // public GameObject t1;
    // public GameObject t2;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")){ //플레이어와 충돌했을 때
            if (GameManager.Instance.isKey){ //열쇠 있을 때
                col.isTrigger = true;
                GameManager.Instance.isLocked = false;
            }
            else{
                // PrintText(GameManager.Instance.isKey);
            }
        }
    }

    // public void PrintText(bool locked){
    //     if (locked){
    //         t1.SetActive
    //     }
    //     else{

    //     }
    // } 
}
