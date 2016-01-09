using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour
{

    Transform bulletSpawn;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
        bulletSpawn = GameObject.Find("BulletSpawn").transform;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            GameObject newBullet = Instantiate(bullet);
            Destroy(newBullet, 10.0f);
            newBullet.transform.position = bulletSpawn.position;
            newBullet.transform.rotation = transform.parent.rotation;
        }
	}
}
