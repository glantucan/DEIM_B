using UnityEngine;
using System.Collections;

public class ObjectPicker : MonoBehaviour {

	private PlayerInventory inventory;

	void Start () {
		this.inventory = this.GetComponent<PlayerInventory>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Pickable") {
			this.inventory.AddObject(other.gameObject);
		}
	}
}
