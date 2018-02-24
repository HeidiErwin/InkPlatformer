using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float Seconds = 3;

    public BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("Character"))
        {
            Debug.Log("hello");
            StartCoroutine(KillBlock());
        }
    }
    IEnumerator KillBlock()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(Seconds);
        Debug.Log("hi2");
        Destroy(bc);
    }
}
