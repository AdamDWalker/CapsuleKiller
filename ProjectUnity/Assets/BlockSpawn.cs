using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour
{

    public GameObject block;

    public uint blockLowerBound = 10;
    public uint blockUpperBound = 20;

    // Size of the floor
    private float areaxSize;
    private float areazSize;
    
    // The floor
    private GameObject floor;
    private MeshRenderer floorMesh;

    // Use this for initialization
    void Start ()
    {
        floor = gameObject;
        floorMesh = floor.GetComponent<MeshRenderer>();

        int blockCount = (int)Random.Range(blockLowerBound, blockUpperBound);
        areaxSize = floorMesh.bounds.size.x / 2; // needs to be halved because counting starts at origin
        areazSize = floorMesh.bounds.size.z / 2;

        spawnBlocks(blockCount);
    }
	
    void spawnBlocks(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Vector3 blockLocation;

            float xPos = Random.Range(-areaxSize, areaxSize);
            float zPos = Random.Range(-areazSize, areazSize);
            blockLocation = new Vector3(xPos, 1.0f, zPos);

            Instantiate(block, blockLocation, Quaternion.identity);
        }
    }
}
