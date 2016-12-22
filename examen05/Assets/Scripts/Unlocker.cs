using UnityEngine;
using System.Collections;

public class Unlocker : MonoBehaviour {

	[SerializeField] private string unlockId;
	[SerializeField] private Animation unlockAnim;

	void OnTriggerEnter(Collider other) {
		Inventory inventory = other.GetComponent<Inventory>();
		if (inventory != null) {
			if (inventory.hasItem(unlockId)) {
				unlockAnim.Play();
			}
		}
	}
}
