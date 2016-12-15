using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private float v;

	// Recibe como parametro el vector de direccion para el movimiento, que tiene que estar normalizado
	public void Move(Vector3 dir) {
		Vector3 displacement = this.v * dir * Time.deltaTime;
		this.transform.position += displacement;
	}
}
