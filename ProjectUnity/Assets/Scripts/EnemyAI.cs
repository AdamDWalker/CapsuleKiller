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
        float mySpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, mySpeed); // move the enemy
    }

    public void Die()
    {
        particles.Emit(20);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1);
    }
}
