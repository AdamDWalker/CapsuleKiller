using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour
{

    Vector3 bulletSpawn;

	// Use this for initialization
	void Start ()
    {
        bulletSpawn = transform.Find("BulletSpawn").position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
