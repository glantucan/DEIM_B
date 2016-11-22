using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;
	private float dragOnGround;
	private List<Collider> groundContacts;
	[SerializeField] private float jumpSpeed;

	[SerializeField] private Transform cameraTr;
	private Vector3 camToPlayerDistance;
	private int cameraAngle;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
					
		this.dragOnGround = this.rb.drag;
		this.groundContacts = new List<Collider>();

		this.camToPlayerDistance = this.cameraTr.position - this.transform.position;
		this.cameraAngle = 0;


	}
	
	// Update is called once per frame
	void Update () {		

		MovePlayer();

		if (Input.GetKeyDown(KeyCode.Q)) {
			if(cameraAngle != 270) {
				cameraAngle = cameraAngle + 90;
			} else {
				cameraAngle = 0;
			}

			this.camToPlayerDistance = new Vector3 (
					this.camToPlayerDistance.z,
					this.camToPlayerDistance.y,
					-this.camToPlayerDistance.x
				);

		} else if (Input.GetKeyDown(KeyCode.E)) {
			if(cameraAngle != 0) {
				cameraAngle = cameraAngle - 90;
			} else {
				cameraAngle = 270;
			}

			this.camToPlayerDistance = new Vector3 (
					-this.camToPlayerDistance.z,
					this.camToPlayerDistance.y,
					this.camToPlayerDistance.x
				);
		}
	}


	void FixedUpdate() {
		// Camera follow
		this.cameraTr.LookAt(this.transform);
		this.cameraTr.position = Vector3.Lerp(this.cameraTr.position, this.transform.position + this.camToPlayerDistance, 0.05F);
	}



	void MovePlayer() {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");

		if (this.cameraAngle == 0) {
			this.direction = xInput * Vector3.right + zInput * Vector3.forward;
		} else if (this.cameraAngle == 90) {
			this.direction = zInput * Vector3.right - xInput * Vector3.forward;
		} else if (this.cameraAngle == 180) {
			this.direction = -xInput * Vector3.right - zInput * Vector3.forward;
		} else if (this.cameraAngle == 270) {
			this.direction = -zInput * Vector3.right + xInput * Vector3.forward;
		}

		// v = v0 + a * t
		// s = s0 + v * t

		if( this.direction.magnitude != 0) {
			// this.rb.velocity = this.direction.normalized * this.speed; // Esto no funciona
			// this.rb.velocity = new Vector3 (this.direction.normalized.x * this.speed, this.rb.velocity.y, this.direction.normalized.z * this.speed);
			this.rb.velocity = this.direction.normalized * this.speed + this.rb.velocity.y * Vector3.up;
		}

		if (groundContacts.Count == 0) {
			this.rb.drag = 0;
		} else {
			if (Input.GetKey (KeyCode.Space)) {
				this.rb.velocity = this.direction.normalized * this.speed + jumpSpeed * Vector3.up;
			}
			this.rb.drag = this.dragOnGround;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ground") {
			groundContacts.Add(other);
		}
	}

	void OnTriggerExit(Collider other) {
		
		if (other.tag == "Ground") {
			groundContacts.Remove(other);
		}
	}

}