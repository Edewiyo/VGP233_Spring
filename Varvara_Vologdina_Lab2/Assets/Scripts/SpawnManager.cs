using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    public GameObject snacksPrefabs;
    public GameObject[] carsPrefabs;
    public GameObject copPrefab;
    public GameObject[] barierPrefabs;


    private List<GameObject> tilesList = new List<GameObject>();

    public GameObject player;

    private float zPositionTile = 0.0f;
    private float xPositionTile = 0.0f;
    private float yPositionTile = 0.0f;

    private int randGapSnacks = 0;
    private int randGapCars = 0;
    private int randGapBariers = 0;


    private Vector3 spawnDirection = new Vector3(0,0,0);

    
    private int spawnedTiles = 0;

    // Start is called before the first frame update
    void Start()
    {
        randGapSnacks = Random.Range(4, 10);
        randGapCars = Random.Range(6, 21);
        randGapBariers = Random.Range(2, 6);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + 120 > zPositionTile)
        {
            SpawnTile(eTileType.Straight);
        }
        if(randGapSnacks == 0)
        {
            SpawnSnack();
            randGapSnacks = Random.Range(4, 10);
        }
        if(randGapCars == 0)
        {
            SpawnCars();
            randGapCars = Random.Range(6, 21);
        }
        if(randGapBariers == 0)
        {
            SpawnBarriers();
            randGapBariers = Random.Range(2, 6);

        }
    }
    void SpawnBarriers()
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
        temp = Instantiate(barierPrefabs[Random.Range(0, barierPrefabs.Length)], new Vector3(randomX, 0, zPositionTile), Quaternion.Euler(spawnDirection)) as GameObject;
    }
    void SpawnTile(eTileType type )
    {
        //Debug.Log(zPositionTile);
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
        }
        
        if(tilesList.Count > 8)
        {
            Destroy(tilesList[0]);
            tilesList.RemoveAt(0);

        }
        ++spawnedTiles;
        --randGapSnacks;
        --randGapCars;
        --randGapBariers;
    }
    void SpawnCars()
    {
        int randomX = -1;
        int random = Random.Range(0, 7);
        int randomCar = Random.Range(0, carsPrefabs.Length);
        switch (random)
        {
            case 0:
                randomX = -3;
                break;
            case 1:
                randomX = -2;
                break;
            case 2:
                randomX = -1;
                break;
            case 3:
                randomX = 0;
                break;
            case 4:
                randomX = 1;
                break;
            case 5:
                randomX = 2;
                break;
            case 6:
                randomX = 3;
                break;

        }
        GameObject temp;
        temp = Instantiate(carsPrefabs[randomCar], new Vector3(randomX, 0, zPositionTile), Quaternion.Euler(spawnDirection)) as GameObject;
        if(randomCar == 2)
        {
            SpawnCop();
        }
    }
    void SpawnCop()
    {
        float carPosition = carsPrefabs[2].transform.position.x;
        if ( carPosition< 0)
        {
            GameObject temp;
            temp = Instantiate(copPrefab, new Vector3(carPosition + 2, 0, zPositionTile), Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
        }
        else if (carPosition >= 0)
        {
            GameObject temp;
            temp = Instantiate(copPrefab, new Vector3(carPosition - 2, 0, zPositionTile), Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
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
        temp = Instantiate(snacksPrefabs, new Vector3(randomX, 1, zPositionTile), Quaternion.Euler(spawnDirection)) as GameObject;

    }
}