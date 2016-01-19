using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

    public int blockRows = 10;
    public int blockColumns = 10;

    private MeshRenderer floor;
    private float width;
    private float depth;

    //private GridNode[,] mygrid;

	// Use this for initialization
	void Start () {
        // get the mesh renderer to calculate the floor bounds
        floor = gameObject.GetComponent<MeshRenderer>();
        width = floor.bounds.size.x;
        depth = floor.bounds.size.z;

        //Vector3 leftPoint =
    }

    // Update is called once per frame
    void Update () {
	
	}
}
