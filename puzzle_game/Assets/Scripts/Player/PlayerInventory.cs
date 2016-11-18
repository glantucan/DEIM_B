using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	[SerializeField] private GameObject[] inventory;
	private int objectCounter;

	private void Start () {
		this.inventory = new GameObject[5];
		this.objectCounter = 0;
	}
	
	public void AddObject(GameObject theObject) {

		if (objectCounter < this.inventory.Length) {
			this.inventory[objectCounter] = theObject;
			theObject.SetActive (false);
			objectCounter = objectCounter + 1;
		} else {
			Debug.Log("No queda sitio en el inventario");
		}
	}

	public GameObject GetObject() {
		GameObject theObject = null;
		if (this.objectCounter > 0) {
			theObject = this.inventory[this.objectCounter-1];
			this.inventory[this.objectCounter-1] = null;
			this.objectCounter = this.objectCounter - 1;
		}
		return theObject;
	}
}
