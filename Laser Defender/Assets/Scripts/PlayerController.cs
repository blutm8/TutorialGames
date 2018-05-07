using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float padding = 1f;

    float xmin;
    float xmax;

    private void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //This is how you would access the X position of the object and how you would change it.
            //here "speed * Time.deltaTime" replaces the X value.

            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            //This is the same as above but in a new and more readable way
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //This is how you would access the X position of the object and how you would change it.
            //here "speed * Time.deltaTime" replaces the X value.

            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            //This is the same as above but in a new and more readable way
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Restrics the player object to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
