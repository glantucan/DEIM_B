using UnityEngine;
using System.Collections;

public class UserInput1 : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q)) {
			// Mover hacia delante
			PlayerMovement movement = this.GetComponent<PlayerMovement>();
			movement.Move(Vector3.forward);
		} else if (Input.GetKey(KeyCode.A)) {
			// Mover hacia atras
			PlayerMovement movement = this.GetComponent<PlayerMovement>();
			movement.Move(-Vector3.forward);
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			// Mover hacia atras
			ShootControl shooter = this.GetComponent<ShootControl>();
			shooter.Shoot();
		}
	}
}
