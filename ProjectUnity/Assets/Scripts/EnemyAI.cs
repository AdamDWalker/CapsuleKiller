using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public float speed = 1.0f;

    private GameObject player;
    private ParticleSystem particles;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // find the player
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPlayerDead)
        {
            float mySpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, mySpeed); // move the enemy
        }

        if (gameObject.transform.position.y < -5)
        {
            reset();
        }
    }

    public void Die()
    {
        // This will emit particles, and make the enemy invisible, untouchable and not move for 1 second until it is destroyed.
        // It seemed easier than bothering to create a new object of particles in the same place as the recently destroyed enemy object.
        particles.Emit(20);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        speed = 0;
        Destroy(gameObject, 1);
    }

    /// <summary>
    /// In case the enemy gets outside of the level somehow, this should reset them back
    /// </summary>
    public void reset()
    {
        gameObject.transform.position = new Vector3(0, 1, 0);
    }
}
