using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);

        Vector3 ballPos = ball.transform.position;

        //limits the paddle to the playfield
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 18.7f); ;

        this.transform.position = paddlePos;
    }
    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 19.2f;

        //limits the paddle to the playfield
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 18.7f); ;

        this.transform.position = paddlePos;
    }
}
