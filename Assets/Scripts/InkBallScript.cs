using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBallScript : MonoBehaviour
{
    private GameObject inkballVisualizer;
    public int moveSpeed = 20;
    Vector3 direction;

    void Awake()
    {
        Destroy(gameObject, 10f);
        inkballVisualizer = transform.GetChild(0).gameObject;
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
        float angle = Vector2.Angle(Vector2.right, direction);
        inkballVisualizer.transform.Rotate(new Vector3(0, 0, angle));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9 || collider.gameObject.layer == 11 || collider.gameObject.layer == 13)
        {
            Destroy(gameObject);
        }
    }

}
