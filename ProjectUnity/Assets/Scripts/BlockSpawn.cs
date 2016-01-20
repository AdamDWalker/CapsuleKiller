using UnityEngine;
using System.Collections;

public class BlockSpawn : MyGrid
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
    private GameObject BlockList;

    // Use this for initialization
    void Start ()
    {
        floor = gameObject;
        floorMesh = floor.GetComponent<MeshRenderer>();

        int blockCount = (int)Random.Range(blockLowerBound, blockUpperBound);
        areaxSize = floorMesh.bounds.size.x / 2; // needs to be halved because counting starts at origin
        areazSize = floorMesh.bounds.size.z / 2;

        BlockList = new GameObject();
        BlockList.name = "Level";

        createGrid(floor.GetComponent<MeshRenderer>());

        spawnBlocks(blockCount);
    }
	
    void spawnBlocks(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GridNode randomNode = getBlockSpawn();

            if (randomNode.isWalkable())
            {
                randomNode.setWalkable(false);

                Vector3 blockLocation = randomNode.getCentrePosition();
                blockLocation.y = block.transform.position.y;

                Vector2 nodeDimensions = randomNode.getDimensions();

                GameObject newBlock;
                newBlock = Instantiate(block, blockLocation, Quaternion.identity) as GameObject;
                newBlock.transform.localScale = new Vector3(1.0f * nodeDimensions.x, newBlock.transform.localScale.y, 1.0f * nodeDimensions.y);
                newBlock.transform.parent = BlockList.transform;

            }

        }
    }
}
