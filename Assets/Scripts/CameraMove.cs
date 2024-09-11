using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float deadline = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= deadline)
        {
            rb.velocityX = 0;
        }
    }
    public void StageLoad()
    {
        Debug.Log("카메라 무브");
        deadline = transform.position.x + 17.3f;
        //while(transform.position.x <= deadline)
        //{
            rb.velocityX = 20f;
        //}
    }
}
