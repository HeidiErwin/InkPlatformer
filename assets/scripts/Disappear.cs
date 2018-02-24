using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float Seconds = 3;
    private SpriteRenderer m_SpriteRenderer;
    public BoxCollider2D bc;
    private bool solidified = true;
    void Start()
    {
       m_SpriteRenderer = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            if (solidified)
            {
                StartCoroutine(Unsolidify());
            }
            // StartCoroutine(KillBlock());
        }
        else if (other.gameObject.layer == 10)
        {
            m_SpriteRenderer.color = Color.black;
            gameObject.layer = 9;
            solidified = true;
        }
    }
    IEnumerator Unsolidify()
    {
        yield return new WaitForSeconds(Seconds);
        solidified = false;
        gameObject.layer = 11;
        m_SpriteRenderer.color = Color.red;
    }
    IEnumerator KillBlock()
    {
        yield return new WaitForSeconds(Seconds);
        m_SpriteRenderer.color = Color.red;
        Destroy(bc);
    }
}
