using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    public GameObject target;


    void Update()
    {

        target.SetActive(!GameManager.Instance.isGameStart);
        if (Input.anyKeyDown)
        {
            GameManager.Instance.isGameStart = true;
        }
    }
}
