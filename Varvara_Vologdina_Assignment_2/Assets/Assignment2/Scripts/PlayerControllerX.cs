using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float Run = 0.5f; 
    private float nextRun;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextRun)
        {
            nextRun = Time.time + Run;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
