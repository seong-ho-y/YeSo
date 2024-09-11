using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform player;
    public bool isKey;
    Collider2D col;
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.enabled = GameManager.Instance.isLocked;
        if (isKey)
        {
            col.isTrigger = true;
            if(GameManager.Instance.player_right){
                transform.position = player.position + new Vector3(0.2f, -0.1f, 0f);
                sr.flipX = false;
            }
            else{
                transform.position = player.position + new Vector3(-0.2f, -0.1f, 0f);
                sr.flipX = true;
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.isKey = true;
            Debug.Log("열쇠 획득");
            isKey = true;
        }
    }
}
