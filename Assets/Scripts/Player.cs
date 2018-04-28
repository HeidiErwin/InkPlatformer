﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public AudioClip deathSound;
    public bool isDead = false;
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public bool canDoubleJump;
    private bool isDoubleJumping = false;
	private bool jumpable = true;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;
    private AudioSource source;

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
    private Vector3 velocity;
    private float velocityXSmoothing;

    private Controller2D controller;

    private Vector2 directionalInput;
    private bool wallSliding;
    private int wallDirX;

    private bool showRestartPopup = false;

    private void Start()
    {
        //source = GetComponent();
        controller = GetComponent<Controller2D>();
        source = gameObject.AddComponent<AudioSource>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
        CalculateVelocity();
        HandleWallSliding();

        if (!isDead)
        {
            controller.Move(velocity * Time.deltaTime, directionalInput);
        }

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }

		if (this.transform.position.y < -10) {
			Death ();
		}
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

	public void Death() {
        showRestartPopup = true;
        source.PlayOneShot(deathSound, .4f);
        this.isDead = true;
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    void OnGUI()
    {
        if (showRestartPopup)
            GUI.Label(new Rect(20, Screen.height-50, 100, 100), "Press 'R' to Restart Level");
    }

    //this was gonna handle spikes
    //	public void OnTriggerEnter2D(Collider2D other) {
    //		//print ("colliding");
    //		if (other.gameObject.layer == 12) {
    //			Disappear d = other.gameObject.GetComponent<Disappear>();
    //			//Debug.Log (d.solid);
    //			//Death ();
    //		}
    //	}

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
			if (jumpable) {
				if (wallDirX == directionalInput.x) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				} else if (directionalInput.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				} else {
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				}
				isDoubleJumping = false;
			} else {
				if (wallDirX == directionalInput.x) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = 0;
				} else if (directionalInput.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = 0;
				} else {
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = 0;
				}
				isDoubleJumping = false;
			}
        }
        if (controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = false;
        }
        if (canDoubleJump && !controller.collisions.below && !isDoubleJumping && !wallSliding)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = true;
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    private void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0f)
            {
                velocityXSmoothing = 0f;
                velocity.x = 0f;
                if (directionalInput.x != wallDirX && directionalInput.x != 0f)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == 13) {
			jumpable = false;
		} else {
			jumpable = true;
		}
	}
}
