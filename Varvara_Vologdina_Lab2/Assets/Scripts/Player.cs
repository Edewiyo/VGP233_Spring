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
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        

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
    }
}
