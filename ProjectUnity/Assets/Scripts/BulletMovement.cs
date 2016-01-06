using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    GameObject bullet;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        bullet = gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    bullet.transform.position += (transform.forward * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collision)
    {
        if ( collision.tag == "Enemy" )
        {
            Destroy(collision.gameObject);
            Destroy(bullet);
        }
    }
}
