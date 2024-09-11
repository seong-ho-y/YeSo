using System.Security.Cryptography;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public LayerMask pLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapArea(p1.position, p2.position, pLayer))
        {
            GameManager.Instance.isClimb = true;
        }
        else{
            GameManager.Instance.isClimb = false;
        }
    }
}
