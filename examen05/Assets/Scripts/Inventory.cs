using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private List<string> itemsList;

	void Start() {
		itemsList = new List<string>();
	}
	private void OnTriggerEnter(Collider other) {
		Pickable item = other.GetComponent<Pickable>();
		if (item != null){
			Debug.Log(item.GetId());
			itemsList.Add(item.GetId());
			other.gameObject.SetActive(false);
		}
	}

	public bool hasItem(string id) {
		//return itemsList.Contains(id);
		bool hasIt = false;
		int counter = 0;
		while (counter < itemsList.Count) {
			if (!hasIt) {
				//hasIt = (id == itemsList[counter]);
				if (id == itemsList[counter]) {
					hasIt = true;
					itemsList.Remove(id);
				}
			}
		}
		return hasIt;
	}
}
