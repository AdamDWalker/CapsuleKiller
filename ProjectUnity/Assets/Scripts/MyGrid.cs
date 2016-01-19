using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class MyGrid : MonoBehaviour {

    public int blockRows = 10;
    public int blockColumns = 10;

    private MeshRenderer floor;
    private float width;
    private float depth;

    private GridNode[,] grid;

    public GameObject TestPrefab;

	// Use this for initialization
	void Start () {
        // get the mesh renderer to calculate the floor bounds
        floor = gameObject.GetComponent<MeshRenderer>();
        width = floor.bounds.size.x;
        depth = floor.bounds.size.z;

        Vector3 TopLeftPoint = new Vector3(transform.position.x - (width/2), transform.position.y, transform.position.z + (depth / 2));

        Instantiate(TestPrefab, TopLeftPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
