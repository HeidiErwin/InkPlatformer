using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearV2 : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private bool solidified = false;
    public bool dropWater = true;
    public float dropSpeed = 0.2f;
    private float dripTimer;
    private bool timerRunning;
    public float dripTimerMax = 3f;
    public GameObject inkBallPrefab;
    public GameObject waterPrefab;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        dripTimer = 0f;
        timerRunning = false;
        solidified = false;
        gameObject.layer = 11; // empty layer
        m_SpriteRenderer.color = Color.red;
        if (dropWater)
        {
            InvokeRepeating("DropWater", 0.5f, dropSpeed);
        }

    }

    void PlatformTimer()
    {
        dripTimer += Time.deltaTime;
        if (dripTimer > dripTimerMax)
        {
            // drop ink ball
            DropInk();
            dripTimer = 0f;
            timerRunning = false;
            solidified = false;
            gameObject.layer = 11; // empty layer
            m_SpriteRenderer.color = Color.red;
            if (dropWater)
            {
                InvokeRepeating("DropWater", 0.5f, dropSpeed);
            }
        }
    }

    void DropInk()
    {
        Quaternion ray = new Quaternion(0, -1, 0, 0);
        Vector2 dir = new Vector2(0, -1);
        Vector3 pos = gameObject.transform.position;
        float boxOffset = gameObject.transform.lossyScale.y * gameObject.GetComponent<BoxCollider2D>().size.y / 2;
        pos.y = pos.y - gameObject.transform.localScale.y - inkBallPrefab.GetComponent<CircleCollider2D>().radius - boxOffset;
        var b = (GameObject)Instantiate(inkBallPrefab, pos, ray);
        b.GetComponent<InkBallScript>().SetDirection(dir);
    }

    void DropWater()
    {
        Quaternion ray = new Quaternion(0, -1, 0, 0);
        Vector2 dir = new Vector2(0, -1);
        Vector3 pos = gameObject.transform.position;
        float boxOffset = gameObject.transform.lossyScale.y * gameObject.GetComponent<BoxCollider2D>().size.y / 2;
        float waterOffset = waterPrefab.GetComponent<BoxCollider2D>().size.y * waterPrefab.transform.lossyScale.y / 2;
        pos.y = pos.y - gameObject.transform.localScale.y - waterOffset - boxOffset - 0.01f;
        var b = (GameObject)Instantiate(waterPrefab, pos, ray);
        b.GetComponent<InkBallScript>().SetDirection(dir);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // the Ink's layer
        if (other.gameObject.layer == 10)
        {
            CancelInvoke();
            timerRunning = true;
            m_SpriteRenderer.color = Color.black;
            gameObject.layer = 9; // solidified block layer
            dripTimer = 0f;
            if (solidified)
            {
                // drop ink ball
                DropInk();
            
            } else
            {
                solidified = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            PlatformTimer();
        }
    }
}
