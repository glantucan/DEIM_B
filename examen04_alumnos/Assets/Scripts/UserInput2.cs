using UnityEngine;
using System.Collections;

public class UserInput2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P)) {
			// Mover hacia delante
			PlayerMovement movement = this.GetComponent<PlayerMovement>();
			movement.Move(this.transform.right);
		} else if (Input.GetKey(KeyCode.L)) {
			// Mover hacia atras
			PlayerMovement movement = this.GetComponent<PlayerMovement>();
			movement.Move(-this.transform.right);
		}
		if (Input.GetKeyDown(KeyCode.Comma)) {
			// Mover hacia atras
			Debug.Log("Disparar");
		}
	}
}
