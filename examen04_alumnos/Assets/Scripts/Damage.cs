using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	[SerializeField] private int damage;

	private void OnCollisionEnter(Collision col) {
		Health otherHealth = col.gameObject.GetComponent<Health>();

		if (otherHealth != null) {
			otherHealth.MakeDamage(damage);
		}
	}
}
