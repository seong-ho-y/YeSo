using UnityEngine;

public class BoxDrag : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (GameManager.Instance.isDrag == "Right")
            {rb.MovePosition(player.transform.position + new Vector3(0.6f, -0.1f, 0f));}
        else if (GameManager.Instance.isDrag == "Left"){
            rb.MovePosition(player.transform.position + new Vector3(-0.6f, -0.1f, 0f));
            }
    }
}
