using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   
    private float movementSpeed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject Player;
    private float reactDistance = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        Vector3 lookDirection;
        Vector3 targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        if(distance <= reactDistance)
        {
            if(distance > 5.0f)
            {
                targetPos.z += (distance / 2.0f);
            }
            lookDirection = (targetPos - transform.position).normalized;
            lookDirection.y = 0;
            enemyRb.AddForce(lookDirection * movementSpeed);
        }
        else
        {
            lookDirection = (targetPos - transform.position).normalized;
            enemyRb.AddForce(lookDirection * movementSpeed * 0.2f); 

        }
        if ((transform.position.z - Player.transform.position.z) < -3f)
        {
            Destroy(gameObject);
        }
    }
}
