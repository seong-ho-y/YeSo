using UnityEngine;
using UnityEngine.UI;

public class GreenBar : MonoBehaviour
{
    // 변경할 스프라이트를 여기에 드래그 앤 드롭하세요.
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (GameManager.Instance.colorOnMouse == "green")
        {
            rt.sizeDelta = new Vector2(500f, 100f);
        }
        else{
            rt.sizeDelta = new Vector2(100f, 100f);
        }

    }
}