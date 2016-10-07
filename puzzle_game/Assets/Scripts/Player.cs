using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private bool isNearButton; 

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;
		if( this.direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}

		if (isNearButton) {
			if ( Input.GetKeyUp(KeyCode.Space)) {
				Debug.Log("Interruptor activado");
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("He entrado en el trigger de un " + other.tag);
		if(other.tag == "Switch" ) {
			this.isNearButton = true;
		}
	}

	void OnTriggerExit(Collider other) {
		Debug.Log("He salido en el trigger");
		if(other.tag == "Switch" ) {
			this.isNearButton = false;
		}
	}
}
