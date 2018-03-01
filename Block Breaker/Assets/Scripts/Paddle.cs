using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 19.2f;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 18.7f); ;

        this.transform.position = paddlePos;

	}
}
