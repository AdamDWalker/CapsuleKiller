using UnityEngine;
using System.Collections;

public class Floor : MyGrid {

    // Size of the floor
    private float areaxSize;
    private float areazSize;

    private MeshRenderer floorMesh;

    void Start()
    {
        floorMesh = GetComponent<MeshRenderer>();

        areaxSize = floorMesh.bounds.size.x;
        areazSize = floorMesh.bounds.size.z;
    }

    public Vector2 getSize()
    {
        return new Vector2(areaxSize, areazSize);
    }

    public Vector2 getHalfSize()
    {
        return new Vector2(areaxSize / 2, areazSize / 2);
    }
}
