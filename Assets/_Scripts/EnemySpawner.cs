/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/

// This script set set the spawning point of enemies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class EnemySpawner : MonoBehaviour
{
    // Possible spawn point positions
    public enum SpawnerType
    {
        Static,
        VertDynamic,
        HorDynamic,
        FullDynamic
    }

    [Header("Spawner Type")]
    public SpawnerType spawnerType;

    [Header("Position Status")]
    public Vector3 SpawnPosition;

    [SerializeField]
    public Boundary boundary;

    //Currently Not Used, May be used eventually when implementing a moving game object (attach to Aircraft Carrier)
    [Header("Speed Variables")]
    [SerializeField]
    public Speed HorSpeedRange;
    public Speed VerSpeedRange;
    public float horSpeed;
    public float verSpeed;

    // List of Enemy Objects to Spawn
    public GameObject[] Enemies;
    
    // The next time to spawn
    public float nextTimetoSpawn;

    [SerializeField]
    // Interval time to spawn for each enemy in list
    public float[] intervalTime;

    //These variables keeps track of which enemy to spawn and the time diff in spawning each enemy
    int enemyCounter = 0;
    int enemyIntervalCounter = 0;
    int intervalTimeLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = transform.position;
        intervalTimeLength = intervalTime.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the time is ready for next spawn
        if (nextTimetoSpawn <= Time.time)
        {
            //Set the next time to spawn
            nextTimetoSpawn = Time.time + intervalTime[enemyIntervalCounter];
            SpawnEnemies();

        }
    }

    //Spawn the enemy, and reset the the enemy back to beginning if its at the end of the enemies list;
    void SpawnEnemies()
    {
        //Depends on the spawner type of the spawner, spawn the game object
        switch (spawnerType)
        {
            case SpawnerType.Static:
                Instantiate(Enemies[enemyCounter], SpawnPosition, transform.rotation);
                break;
            case SpawnerType.HorDynamic:
                RandPositionHor();
                Instantiate(Enemies[enemyCounter], SpawnPosition, transform.rotation);
                break;
            case SpawnerType.VertDynamic:
                RandPositionVer();
                Instantiate(Enemies[enemyCounter], SpawnPosition, transform.rotation);
                break;
            case SpawnerType.FullDynamic:
                RandPositionHor();
                RandPositionVer();
                Instantiate(Enemies[enemyCounter], SpawnPosition, transform.rotation);
                break;
            default:
                Instantiate(Enemies[enemyCounter], SpawnPosition, transform.rotation);
                break;
        }
        enemyCounter += (enemyCounter+1 < Enemies.Length) ? 1 : -Enemies.Length+1;
        enemyIntervalCounter += (enemyIntervalCounter+1 < intervalTime.Length) ? 1 : -intervalTime.Length+1;
    }

    //Randomize Horizontal Position
    void RandPositionHor()
    {
        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);
        SpawnPosition.x = randomXPosition;
    }

    //Randomize Vertical Position
    void RandPositionVer()
    {
        float randomYPosition = Random.Range(boundary.TopBounds, boundary.BottomBounds);
        SpawnPosition.y= randomYPosition;
    }
}
