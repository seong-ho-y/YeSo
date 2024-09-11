using UnityEngine;

public class isLadder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public bool test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.Instance.isClimbing);
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("인풋 받기");
            test = true;
        }
        else
        {
            test = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("충돌");
        if((collision.gameObject.layer == LayerMask.NameToLayer("Player")) && test)
        {
            GameManager.Instance.isClimbing = true;
            Debug.Log("제발");
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.1f, player.transform.position.z);
            
        }
    }
}
