using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    public GameObject[] snacksPrefabs;

    private List<GameObject> tilesList = new List<GameObject>();

    public GameObject player;

    private float zPositionTile = 0.0f;
    private float xPositionTile = 0.0f;
    private float yPositionTile = 0.0f;


    private Vector3 spawnDirection = new Vector3(0,0,0);

    private int currentTileIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + 120 > zPositionTile)
        {
            SpawnTile(eTileType.Straight);
            SpawnSnack();
        }

    }

    void SpawnTile(eTileType type )
    {
        Debug.Log(zPositionTile);
        GameObject temp;
       for (int i =0; i< tilesPrefabs.Length; ++i)
       {
            if(type == tilesPrefabs[i].GetComponent<TileType>().type)
            {
                temp = Instantiate(tilesPrefabs[i], new Vector3(xPositionTile, yPositionTile, zPositionTile), Quaternion.Euler(spawnDirection)) as GameObject;
                tilesList.Add(temp);
                break;
            }
       }

        switch (type)
        {
            case eTileType.Straight:
                zPositionTile += 30;
                break;
            case eTileType.Turn:

                break;
        }
        
        if(tilesList.Count > 8)
        {
            Destroy(tilesList[0]);
            tilesList.RemoveAt(0);

        }
    }

    void SpawnSnack()
    {
        int randomX = -1;
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                randomX = -3;
                break;
            case 1:
                randomX = 0;
                break;
            case 2:
                randomX = 3;
                break;

        }
        GameObject temp;
        temp = Instantiate(snacksPrefabs[Random.Range(0,snacksPrefabs.Length)], new Vector3(randomX, 1, zPositionTile), Quaternion.Euler(spawnDirection)) as GameObject;

    }
}