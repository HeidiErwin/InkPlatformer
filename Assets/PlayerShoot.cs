using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject inkBall;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fire();
        }
    }

    void Fire()
    {
        inkBall = (GameObject)Instantiate(
            inkBall, this.transform.position, inkBall.transform.rotation);
    }

}
