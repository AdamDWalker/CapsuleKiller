using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public int speed = 5;
    public LayerMask lineLayer;

    private Rigidbody playerRigidbody;
	private Vector3 Velocity;
    private GameObject LineSpawn;
    private LineRenderer PlayerLine;
	private float playerYVal = 1.0f;

	// Use this for initialization
	void Start () {

		playerRigidbody = GetComponent<Rigidbody> ();

        LineSpawn = GameObject.Find("BulletSpawn");
        PlayerLine = LineSpawn.GetComponent<LineRenderer>();

	}

	void Update() {
	
		Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
		Velocity = moveInput.normalized * speed;

		// If the player spawns inside the floor or gets flung into the air this should put them back in the proper place
		if ((gameObject.transform.position.y < 1 && gameObject.transform.position.y > -1) || gameObject.transform.position.y > 2) 
		{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 1.0f, gameObject.transform.position.z);
		}

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

            RaycastHit rayHitPoint;

            // draw a line from the gun outwards
            // raycast to find the point of intersection
            if (Physics.Raycast(LineSpawn.transform.position, transform.forward, out rayHitPoint, 50.0f, lineLayer))
            {
                // find distance between the 2 points
                float lineDistance = Vector3.Distance(LineSpawn.transform.position, rayHitPoint.point);
                // set the end point of the line
                PlayerLine.SetPosition(1, new Vector3(0, 0, lineDistance));
            }
        }
    }
}
