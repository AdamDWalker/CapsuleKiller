using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class MyGrid : MonoBehaviour {

    public int blockRows = 10;
    public int blockColumns = 10;

    private MeshRenderer floor;
    private float floor_width;
    private float floor_depth;

    private float block_width;
    private float block_depth;

    private GridNode[,] grid;

	// Use this for initialization
	protected void createGrid (MeshRenderer f) {
        // get the mesh renderer to calculate the floor bounds
        floor = f;
        floor_width = floor.bounds.size.x;
        floor_depth = floor.bounds.size.z;

        // init grid array
        grid = new GridNode[blockRows, blockColumns];

        // calculate the block width & depth
        block_width = floor_width / blockRows;
        block_depth = floor_depth / blockColumns;

        // get the top left point to draw from
        Vector3 TopLeftPoint = new Vector3(transform.position.x - (floor_width/2), transform.position.y, transform.position.z + (floor_depth / 2));

        // the current position of the new block in the loop
        Vector3 currentPosition = TopLeftPoint;

        // loop through to add the blocks (nodes) to the grid
        for (int i = 0; i < blockRows; i++)
        {
            for (int j = 0; j < blockColumns; j++)
            {
                grid[i, j] = new GridNode(currentPosition, new Vector2(block_width, block_depth)); // add a node at the current position
                currentPosition.x += block_width; // move to the right one block
            }
            // move to the next row
            currentPosition.x = TopLeftPoint.x;
            currentPosition.z -= block_depth;
        }
    }

    // For testing in the editor
    void OnDrawGizmos()
    {
        if (grid != null)
        {
            foreach (GridNode n in grid)
            {
                Vector3 cubePosition = n.getCentrePosition();
                Gizmos.color = Color.black;
                Gizmos.DrawWireCube(cubePosition, new Vector3(block_width, 0.1f, block_depth));
                Gizmos.color = Color.yellow;
                Gizmos.DrawCube(cubePosition, new Vector3(block_width, 0.1f, block_depth));
            }
        }
    }

    protected GridNode getBlockSpawn()
    {
        int row = Random.Range(0, blockRows);
        int col = Random.Range(0, blockColumns);

        return grid[row,col];
    }
}
