using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public int speed = 5;
	Rigidbody playerRigidbody;
	Vector3 Velocity;

	// Use this for initialization
	void Start () {

		playerRigidbody = GetComponent<Rigidbody> ();

	}

	void Update() {
	
		Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		Velocity = moveInput.normalized * speed;

	}

	// Update is called once per frame
	void FixedUpdate () {

		playerRigidbody.MovePosition (playerRigidbody.position + Velocity * Time.fixedDeltaTime);
	}
}
