﻿using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnSpeed = 10.0f;

    // waves of enemies
    public uint enemyLowerBound = 3;
    public uint enemyUpperBound = 6;

    // radius around player that enemies will not spawn
    public float spawnRadius = 3;

    private Floor floor;

    private float timerValue;

    // player game object
    private GameObject player;

    private static int waveCount = 0;

	// Use this for initialization
	void Start () {
        floor = GetComponent<Floor>(); // find the floor game object

        timerValue = spawnSpeed;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static int getWave()
    {
        return waveCount;
    }

	// Update is called once per frame
	void Update () {
        if (!GameManager.isPlayerDead)
        {
            timerValue -= Time.deltaTime;

            if (timerValue <= 0.0f)
            {
                timerValue = spawnSpeed; // reset timer

                spawnEnemies();
            }
        }
	}

    void spawnEnemies()
    {
        Vector2 floorSize = floor.getHalfSize();
        // make the enem(ies)
        int enemy_count = (int)Random.Range(enemyLowerBound, enemyUpperBound); // generate a random number of enemies
        for (int i = 0; i < enemy_count; i++) // loop to create them
        {
            Vector3 EnemyLocation;
            bool success = true;
            do
            {
                success = true;

                // calculate enemy location using width and depth of the plane
                float xPos = Random.Range(-floorSize.x, floorSize.x);
                float zPos = Random.Range(-floorSize.y, floorSize.y);
                EnemyLocation = new Vector3(xPos, 1.0f, zPos);

                float playerX = player.transform.position.x;
                float playerZ = player.transform.position.z;

                if ((playerX + spawnRadius) > EnemyLocation.x && (playerX - spawnRadius) < EnemyLocation.x &&
                    (playerZ + spawnRadius) > EnemyLocation.z && (playerZ - spawnRadius) < EnemyLocation.z)
                {
                    Debug.Log("Too close");
                    success = false;
                }

            } while (!success);

            Instantiate(enemy, EnemyLocation, Quaternion.identity);
        }
        waveCount++;
        ScoreScript.updateWaveCount(waveCount);
    }
}
