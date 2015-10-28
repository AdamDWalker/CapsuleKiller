using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public float speed = 1.0f;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // find the player
    }

    // Update is called once per frame
    void Update()
    {
        float mySpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, mySpeed); // move the enemy
    }
}
