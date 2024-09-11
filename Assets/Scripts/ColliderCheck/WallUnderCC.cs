using UnityEngine;

public class WallUnderCC : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (GameManager.Instance.player_right){
            transform.position = player.transform.position + new Vector3(0.2f, -0.1f, 0f);
        }
        else{
            transform.position = player.transform.position + new Vector3(-0.2f, -0.1f, 0f);
        }

    }
}