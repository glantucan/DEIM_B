using UnityEngine;
using System.Collections;

public class Mru_physics : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = new Vector3(0F, 0F, 5F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
