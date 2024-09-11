using UnityEngine;
using UnityEngine.Timeline;

public class BackGround : MonoBehaviour
{
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(114/255f, 100/255f, 81/255f); //배경 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.BGcolor == "gray")
        {
            sr.color = new Color(114/255f, 100/255f, 81/255f);
        }
        if (GameManager.Instance.BGcolor == "red")
        {
            sr.color = new Color(229/255f, 167/255f, 168/255f);
        }
        if (GameManager.Instance.BGcolor == "green")
        {
            sr.color = new Color(195/255f, 219/255f, 195/255f);
        }
        if (GameManager.Instance.BGcolor == "blue")
        {
            sr.color = new Color(140/255f, 142/255f, 204/255f);
        }
    }
}
