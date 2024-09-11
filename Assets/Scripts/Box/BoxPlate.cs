using UnityEngine;

public class BoxPlate : MonoBehaviour
{
    SpriteRenderer sr;
    Transform tr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Box"){ //Layer와 Tag모두 사용하고 있으므로 이름으로 확인
            GameManager.Instance.isBox = true;
            tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y - 0.08f, tr.localScale.z);
            Debug.Log("찰칵");
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Box"){ //Layer와 Tag모두 사용하고 있으므로 이름으로 확인
            GameManager.Instance.isBox = false;
            tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y + 0.08f, tr.localScale.z);
            Debug.Log("박스 없음");
        }
    }
}
