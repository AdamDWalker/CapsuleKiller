using UnityEngine;
using System.Collections;

public class GridNode : MonoBehaviour {

    private Vector3 position; // centre position
    private bool walkable;

	public GridNode(Vector3 pos)
    {
        position = pos;
    }

    public Vector3 getPosition()
    {
        return position;
    }
}
