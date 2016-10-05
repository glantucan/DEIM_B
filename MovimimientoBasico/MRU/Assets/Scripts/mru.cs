using UnityEngine;
using System.Collections;

public class mru : MonoBehaviour {

	public float v;
	private Vector3 velocityVector;
	private Vector3 displacement;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float xDirection = Input.GetAxisRaw("Horizontal");
		float zDirection = Input.GetAxisRaw("Vertical");
		Vector3 direction =   xDirection * Vector3.right +  zDirection * Vector3.forward;
		Vector3 dirNorm = direction.normalized;
		this.displacement = this.v * dirNorm * Time.deltaTime;
		this.transform.position = this.transform.position + this.displacement;
	}
}
