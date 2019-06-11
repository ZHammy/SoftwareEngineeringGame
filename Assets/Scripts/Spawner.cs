using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;

    private float timeBtwSpawn;
    public float startTimeBtwnSpawn;

    private void Start()
    {
        timeBtwSpawn = startTimeBtwnSpawn;
    }

    private void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            int randPos = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwnSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}
