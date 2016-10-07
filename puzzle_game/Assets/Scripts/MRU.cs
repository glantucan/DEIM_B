using UnityEngine;
using System.Collections;

public class MRU : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;
		Vector3 velocity = this.speed * this.direction.normalized;
		transform.position = transform.position + velocity * Time.deltaTime;
	}
}
