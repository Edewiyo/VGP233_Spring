using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DetectCollision : MonoBehaviour
{
    int foodCount = 0;
    public TMP_Text foodScore;
    public TMP_Text scoreText;
    float mScore = 0f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        mScore =mScore+ Time.deltaTime;
        scoreText.text = ((int)mScore).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            ++foodCount;
            mScore = mScore + foodCount;
            foodScore.text = foodCount.ToString();
            Destroy(other.gameObject);
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("car"))
        {
            player.isGameOver = true;
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().GameOver();

        }
        else if (collision.gameObject.CompareTag("cop"))
        {
            player.isGameOver = true;
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().GameOver();

        }
        else if (collision.gameObject.CompareTag("barrier"))
        {
            player.isGameOver = true;
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().GameOver();

        }
    }
}
