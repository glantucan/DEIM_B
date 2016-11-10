using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vectores03 : MonoBehaviour {
	public SimpleMove mover;

	private void Start () {
		//Ejemplo:
		mover.SetInitialPosition(new Vector3(4, 0, -4));
		mover.Move(-2 * Vector3.right);
		mover.Move(5 * Vector3.forward);

	}
}