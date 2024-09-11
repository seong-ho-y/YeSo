using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChange : MonoBehaviour
{
    public GameObject self;
    void Start()
    {
        self.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //마우스 좌클릭 눌렀을 때 시작
        {
            self.SetActive(true);
        
        }
        else if (Input.GetMouseButtonUp(0))
            {
                self.SetActive(false);
            }
    }
}
