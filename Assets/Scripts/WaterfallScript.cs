using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallScript : MonoBehaviour
{
    public int moveSpeed = 20;
    Vector3 direction;

    void Awake()
    {
        Destroy(gameObject, 10f);
    }

    // Use this for initialization
    void Start()
    {
        // layer 8 is the player layer
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8, true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = new Vector2(dir.x, dir.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9 || collider.gameObject.layer == 11 || collider.gameObject.layer == 13)
        {
            Destroy(gameObject);
        }
    }

}
