using UnityEngine;
using UnityEngine.UI;

public class ChangeUIImage : MonoBehaviour
{
    // 변경할 스프라이트를 여기에 드래그 앤 드롭하세요.
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (GameManager.Instance.colorOnMouse == "red")
        {
            rt.sizeDelta = new Vector2(100f, 700f);
        }
        else{
            rt.sizeDelta = new Vector2(100f, 100f);
        }

    }
}