using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 45.0f;
    private float reverse = 180.0f;
    private float horizontalInput;

    private float rotate;
    private bool isForward = true;
    public bool isGameOver = false;
    public bool isDead = false;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true) { return; }
        horizontalInput = Input.GetAxis("Horizontal");
        if(transform.position.z  >= 100)
        {
            speed = 15.0f;
        }
        else if (transform.position.z >= 500)
        {
            speed = 25.0f;
        }
        else if (transform.position.z >= 1000)
        {
            speed = 35.0f;
        }
        else if (transform.position.z >= 30000)
        {
            speed = 55.0f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(isForward)
            {
               isForward = false;
               transform.Rotate(Vector3.down, reverse);

            }
            else
            {
                isForward = true;
                transform.Rotate(Vector3.down, reverse);
            }
        }


        if (isForward)
        {
           transform.Translate(Vector3.forward * Time.deltaTime * speed);
           transform.Rotate(Vector3.down, turnSpeed * horizontalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            transform.Rotate(Vector3.down, turnSpeed * horizontalInput * Time.deltaTime);
        }

        if(transform.position.y < -5 && isGameOver==false)
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().GameOver();
            isGameOver = true;

        }
    }
}
