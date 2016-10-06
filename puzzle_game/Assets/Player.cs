using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward; 
		if (direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}
	}
}
