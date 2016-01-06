using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour
{

    Vector3 bulletSpawn;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
        bulletSpawn = transform.Find("BulletSpawn").position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            GameObject newBullet = new GameObject();
            newBullet.transform.parent = gameObject.transform;
            newBullet.transform.position = bulletSpawn;
            Instantiate(newBullet);
        }
	}
}
