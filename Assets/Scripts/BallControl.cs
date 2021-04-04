using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {
    float mySpeed = -100f;
    public int score = 0;
    public Rigidbody2D ball;
    public Text Score;

	// Use this for initialization
	void Start ()
    {
        Score.text = "0";
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            float myInitAngle = UnityEngine.Random.Range(30.0f, 120.0f) * Mathf.Deg2Rad;
            float myInitXSpeed = mySpeed * Mathf.Sin(myInitAngle);
            float myInitYSpeed = mySpeed * Mathf.Cos(myInitAngle);

            ball.velocity = new Vector2(myInitXSpeed, myInitYSpeed);
        }
    }

    public float getSpeed()
    {
        return mySpeed;
    }
    
    public void RacketHitSpeedIncrease()
    {
        mySpeed = mySpeed*1.05f;
        ball.velocity = ball.velocity.normalized * mySpeed;
    }

    public void UpdateScore()
    {
        score = score + Mathf.Abs(Mathf.RoundToInt(mySpeed)) * 10;
        GameScreenUI gameScreenUI = GameObject.FindObjectOfType(typeof(GameScreenUI)) as GameScreenUI;
        Score.text = score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log("ball speed is:" + this.GetComponent<Rigidbody2D>().velocity);
        Debug.Log("right racket speed is: " + GameObject.Find("RightHandRacket").GetComponent<Rigidbody2D>().velocity);
        Debug.Log("left racket speed is: " + GameObject.Find("LeftHandRacket").GetComponent<Rigidbody2D>().velocity);
        Debug.Log("relative speed is: " + collisionInfo.relativeVelocity);

    }
}
