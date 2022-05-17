using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public variables
    public float secondsBetweenSpawning = 0.2f;
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 1.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;

    public GameObject[] spawnObjects; //what prefabs to spawn 

    private float nextSpawnTime;

    // Use this for initialization
    void Start()
    {
        //determine when to spawn the next Object
        nextSpawnTime = Time.time + secondsBetweenSpawning; //Time.time represents the CURRENT TIME in the game.
    }

    // Update is called once per frame
    void Update()
    {
        //exit if gamemanager exists and the game is over
        if(GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        //if the current time i.e. the remaining time is >= nextSpawnTime 
        if (Time.time >= nextSpawnTime)
        {
            MakeThingToSpawn();

            //determine the next time to spawn
            nextSpawnTime = Time.time + secondsBetweenSpawning;
        }
            
    }

    void MakeThingToSpawn()
    {
        Vector3 spawnPosition;

        //get the random positions between the specified ranges
        spawnPosition.x = Random.Range (xMinRange, xMaxRange);
        spawnPosition.y = Random.Range (yMinRange, yMaxRange);
        spawnPosition.z = Random.Range (zMinRange, zMaxRange);

        //determint which object to spawn
        int objectToSpawn = Random.Range (0, spawnObjects.Length);

        //now spawn the GameObject
        GameObject spawnedObject = Instantiate (spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        //make spawner the parent, o that our hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
    }
}










