using UnityEngine;
using System.Collections;

public class ResetPlayer : MonoBehaviour 
{

	Vector3 playerStartPoint;

	void Start()
	{
		playerStartPoint = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		if(gameObject.transform.position.y < -5.0f)
		{
			gameObject.transform.position = playerStartPoint;
		}
	}
}
