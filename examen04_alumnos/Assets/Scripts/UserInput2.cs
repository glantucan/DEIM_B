using UnityEngine;
using System.Collections;

public class UserInput2 : MonoBehaviour {
	// Update is called once per frame
	private void Update () {
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
			ShootControl shooter = this.GetComponent<ShootControl>();
			shooter.Shoot();
		}
	}
}
