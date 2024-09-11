using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Transform tr;
    SpriteRenderer sr;
    Collider2D col;
    public bool trigger = true;
    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isBox)
        {
            OpenGate(trigger);
        }
        else if (!trigger)
        {
            CloseGate(trigger);
        }
    }
    void OpenGate(bool t){
        if (t){
            tr.SetLocalPositionAndRotation(new Vector3(tr.localPosition.x + 0.4f, tr.localPosition.y, tr.localPosition.z), Quaternion.Euler(0, 0, 90));
        }
        trigger = false;
    }
    void CloseGate(bool t)
    {
        if (!t)
        {
            tr.SetLocalPositionAndRotation(new Vector3(tr.localPosition.x - 0.4f, tr.localPosition.y, tr.localPosition.z), Quaternion.Euler(0, 0, 0));
        }
        trigger = true;
    }
}
