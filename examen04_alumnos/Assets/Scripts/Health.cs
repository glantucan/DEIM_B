using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] private int health;

	public void MakeDamage(int dam) {
		this.health -= dam;
		if (this.health <= 0) {
			Debug.Log("El jugador " + this.name + " ha muerto.");
		}
	}
}
