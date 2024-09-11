using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPointer : MonoBehaviour
{
    private Light2D light2D;

    void Start()
    {
        // Light2D ������Ʈ�� �����ɴϴ�.
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�մϴ�.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D ȯ�濡���� Z�� ���� 0���� �����մϴ�.

        // ����Ʈ�� ��ġ�� ���콺 ��ġ�� �̵���ŵ�ϴ�.
        light2D.transform.position = mousePosition;
    }
}