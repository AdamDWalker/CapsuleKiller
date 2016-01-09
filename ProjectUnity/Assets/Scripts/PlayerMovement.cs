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

        // create a ray from the camera to the to where the mouse is
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float camDistance = 50;

        // debug raycast (viewable in scene view)
        Debug.DrawRay(camRay.origin, camRay.direction*camDistance, Color.green);

        // create a plane to detect the collision 
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);

        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable
        float distance = 0;
        // if the ray hits the plane...
        if (hPlane.Raycast(camRay, out distance))
        {
            // get the hit point
            Vector3 hitPoint = camRay.GetPoint(distance);

            // make the player look at the point
            transform.LookAt(new Vector3(hitPoint.x, transform.position.y, hitPoint.z));
        }
    }
}
