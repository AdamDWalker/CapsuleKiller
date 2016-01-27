using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour
{

    public GameObject block;

    public uint blockLowerBound = 10;
    public uint blockUpperBound = 20;
    
    // The floor
    private Floor floor;
    private GameObject BlockList;

    // Use this for initialization
    void Start ()
    {
        floor = GetComponent<Floor>();

        int blockCount = (int)Random.Range(blockLowerBound, blockUpperBound);

        BlockList = new GameObject();
        BlockList.name = "Level";

        spawnBlocks(blockCount);

        GameObject.FindGameObjectWithTag("Player").GetComponent<playerSpawn>().SpawnPlayer();
    }
	
    void spawnBlocks(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GridNode randomNode = floor.getBlockSpawn();

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
