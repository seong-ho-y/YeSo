using UnityEngine;

public class GroundCC : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (GameManager.Instance.player_right){
            transform.position = player.transform.position + new Vector3(0.12f, -0.5f, 0f);
        }
        else{
            transform.position = player.transform.position + new Vector3(-0.12f, -0.5f, 0f);
        }

    }
}