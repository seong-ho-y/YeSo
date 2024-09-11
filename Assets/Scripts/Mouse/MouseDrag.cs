using Unity.VisualScripting;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 lastMousePosition;
    SpriteRenderer sr;
    private bool isDragging = false;

    void Start()
    {
        // 화면 중앙 좌표를 월드 좌표로 변환
        Vector3 centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 worldCenterPosition = Camera.main.ScreenToWorldPoint(centerPosition);
        worldCenterPosition.z = 0; // Z축 고정

        // 스프라이트를 화면 중앙에 배치
        transform.position = worldCenterPosition;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 누른 순간의 위치를 저장
            GameManager.Instance.isClick = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePosition.z = 0;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            // 현재 마우스 위치 가져오기
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0;

            // 마우스의 이동 방향 계산
            Vector3 direction = currentMousePosition - lastMousePosition;

            // 스프라이트 이동
            transform.position += direction;

            // 현재 마우스 위치를 다음 프레임을 위한 기준점으로 설정
            lastMousePosition = currentMousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            sr.enabled = false;
            Vector3 centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 worldCenterPosition = Camera.main.ScreenToWorldPoint(centerPosition);
            worldCenterPosition.z = 0;
            transform.position = worldCenterPosition;
            
            
        }
    }
}