using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnSpeed = 10.0f;

    // batches of enemies
    public uint enemyLowerBound = 3;
    public uint enemyUpperBound = 6;

    // for how big the plane (floor) is
    private float areaxSize;
    private float areazSize;

    private GameObject floor;
    private MeshRenderer floorMesh;

    private float timerValue;

	// Use this for initialization
	void Start () {
        floor = gameObject; // find the floor game object
        floorMesh = floor.GetComponent<MeshRenderer>(); // get the mesh (to calc the bounds)

        // find the size of the bounds
        areaxSize = floorMesh.bounds.size.x / 2; // needs to be halved because counting starts at origin
        areazSize = floorMesh.bounds.size.z / 2;

        timerValue = spawnSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.isPlayerDead)
        {
            timerValue -= Time.deltaTime;

            if (timerValue <= 0.0f)
            {
                timerValue = spawnSpeed; // reset timer

                spawnEnemy();
            }
        }
	}

    void spawnEnemy()
    {
        // make the enem(ies)
        int enemy_count = (int)Random.Range(enemyLowerBound, enemyUpperBound); // generate a random number of enemies
        for (int i = 0; i < enemy_count; i++) // loop to create them
        {
            // calculate enemy location using width and depth of the plane
            float xPos = Random.Range(-areaxSize, areaxSize);
            float zPos = Random.Range(-areazSize, areazSize);
            Vector3 EnemyLocation = new Vector3(xPos, 1.0f, zPos);

            Instantiate(enemy, EnemyLocation, Quaternion.identity);
        }
    }
}
