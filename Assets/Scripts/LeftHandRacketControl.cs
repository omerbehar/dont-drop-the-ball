using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandRacketControl : MonoBehaviour
{
    public Rigidbody2D paddle;
    public BallControl ballControl;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (paddle.velocity == Vector2.zero) paddle.velocity = new Vector2(0, 20);
            paddle.AddForce(new Vector2(0, 4000), ForceMode2D.Force);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            paddle.velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (paddle.velocity == Vector2.zero) paddle.velocity = new Vector2(0, -20);
            paddle.AddForce(new Vector2(0, -4000), ForceMode2D.Force);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            paddle.velocity = Vector2.zero;
        }
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Ball")
        {
            ballControl.RacketHitSpeedIncrease();
            ballControl.UpdateScore();
        }
    }
}
