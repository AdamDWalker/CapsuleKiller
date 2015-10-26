using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnSpeed = 1.0f;

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
        timerValue -= Time.deltaTime;

        if (timerValue <= 0.0f)
        {
            timerValue = spawnSpeed; // reset timer

            spawnEnemy();
        }
	}

    void spawnEnemy()
    {
        // calculate enemy location using width and depth of the plane
        float xPos = Random.Range(-areaxSize, areaxSize);
        float zPos = Random.Range(-areazSize, areazSize);
        Vector3 EnemyLocation = new Vector3(xPos, 1.0f, zPos);

        // make the enemy!
        Instantiate(enemy, EnemyLocation, Quaternion.identity);
    }
}
