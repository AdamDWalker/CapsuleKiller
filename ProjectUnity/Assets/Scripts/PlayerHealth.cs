﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 3;
    private ParticleSystem particles;

	// Use this for initialization
	void Start () {
        health = 3;
        particles = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            playerDie();
        }

	}

    void playerDie()
    {
        GameManager.isPlayerDead = true;
        particles.Emit(20);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, 1);
        double enemiesKilled = ScoreScript.getScore();
        int waveCount = EnemySpawn.getWave();
        Debug.Log("Enemies Killed: " + enemiesKilled + " Wave Reached: " + waveCount + " Final Score: " + waveCount * enemiesKilled);
        // Set gamestate to over
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision here");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().Die();
            health -= 1;
            HealthBar.getHealth(health);
            Debug.Log("Collision, health: " + health);
        }
    }
}
