using UnityEngine;
using System.Collections;

public class StoneMovement : MonoBehaviour {

	[SerializeField] private float v;
	private Rigidbody rb;
	private Collider col;

	// Use this for initialization
	void Start () {
		
		this.rb = this.GetComponent<Rigidbody>();
		this.col = this.GetComponent<Collider>();
	}

	// Update is called once per frame
	void Update () {
		if(this.rb.velocity == Vector3.zero) {
			this.col.isTrigger = true;
			this.rb.useGravity = false;
		}
	}

	public void Launch(Vector3 launchDirection) {
		this.rb.velocity = launchDirection.normalized * this.v;
		this.col.isTrigger = false;
		this.rb.useGravity = true;

	}
}
