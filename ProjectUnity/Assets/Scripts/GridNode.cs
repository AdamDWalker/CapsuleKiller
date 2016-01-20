using UnityEngine;
using System.Collections;

public class GridNode {

    private Vector3 position; // centre position
    private Vector2 dimensions;
    private bool walkable;

	public GridNode(Vector3 pos, Vector2 dims)
    {
        position = pos;
        dimensions = dims;
    }

    public Vector3 getPosition()
    {
        return position;
    }

    public Vector3 getCentrePosition()
    {
        return new Vector3(position.x + dimensions.x / 2, position.y, position.z - dimensions.y / 2);
    }

    public bool isWalkable()
    {
        return walkable;
    }

    public void setWalkable(bool walk)
    {
        walkable = walk;
    }

    public Vector2 getDimensions()
    {
        return dimensions;
    }
}
