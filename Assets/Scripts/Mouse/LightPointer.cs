using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPointer : MonoBehaviour
{
    private Light2D light2D;

    void Start()
    {
        // Light2D 컴포넌트를 가져옵니다.
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        // 마우스 위치를 월드 좌표로 변환합니다.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D 환경에서는 Z축 값을 0으로 설정합니다.

        // 라이트의 위치를 마우스 위치로 이동시킵니다.
        light2D.transform.position = mousePosition;
    }
}