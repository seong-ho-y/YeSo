using UnityEngine;

public class FrontCC : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (GameManager.Instance.player_right){
            transform.position = player.transform.position + new Vector3(0.2f, 0f, 0f);
        }
        else{
            transform.position = player.transform.position + new Vector3(-0.2f, 0f, 0f);
        }
    }
}
