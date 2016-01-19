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
        Debug.Log(collision.tag);
        if (collision.tag != "Gun")
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyAI>().Die();
                ScoreScript.increaseScore(1);
            }
            Destroy(bullet);
        }
    }
}
