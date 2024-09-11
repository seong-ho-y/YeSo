using UnityEngine;

public class Color_Change : MonoBehaviour
{
        // 트리거로 설정된 Collider와의 충돌을 감지할 때 사용
    public int i = 0;
    public float radius = 0.1f; // 감지 반경
    public LayerMask layerMask; // 체크할 레이어

    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, layerMask);

        if (collider && Input.GetMouseButtonUp(0)){
            GameManager.Instance.BGcolor = GameManager.Instance.BGcolor_list[i];
            GameManager.Instance.colorOnMouse = "null";
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그가 targetTag와 일치하는지 확인
        if (other.gameObject.tag == "grayCC")
        {
            i = 0;
            GameManager.Instance.colorOnMouse = GameManager.Instance.colorOnMouse_list[i];
        }
        else if (other.gameObject.tag == "redCC")
        {
            i = 1;
            GameManager.Instance.colorOnMouse = GameManager.Instance.colorOnMouse_list[i];
        }
        else if (other.gameObject.tag == "greenCC")
        {
            i = 2;
            GameManager.Instance.colorOnMouse = GameManager.Instance.colorOnMouse_list[i];
        }
        else if (other.gameObject.tag == "blueCC")
        {
            i = 3;
            GameManager.Instance.colorOnMouse = GameManager.Instance.colorOnMouse_list[i];
        }
    }
}