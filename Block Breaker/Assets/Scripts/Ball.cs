using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource audioSource;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    
	// Use this for initialization
	void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks if the game has started. if not, the ball is tacked to the paddle
        if (!hasStarted)
        {
            //tacks the ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //checks if the left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                //shoots the ball away from the paddle
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            audioSource.Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
