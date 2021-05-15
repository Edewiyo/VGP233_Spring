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

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.down, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(Vector3.down, reverse);
            
        }
    }
}
