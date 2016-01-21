using UnityEngine;
using System.Collections;

public class playerSpawn : MonoBehaviour {

    private Floor floor;

	// Use this for initialization
	void Start () {
        floor = GameObject.Find("Floor").GetComponent<Floor>();

        // spawn the player in a random postion
        GridNode n;
        do
        {
            n = floor.getBlockSpawn();
        } while (!n.isWalkable()); // keep finding a different block until it is walkable

        transform.position = n.getCentrePosition();
	}
}
