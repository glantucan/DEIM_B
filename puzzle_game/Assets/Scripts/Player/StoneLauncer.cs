using UnityEngine;
using System.Collections;

public class StoneLauncer : MonoBehaviour {

	private PlayerInventory inventory;

	// Use this for initialization
	void Start () {
		this.inventory = this.GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp(0)){
			GameObject stone = this.inventory.GetObject();
			if (stone != null) {
				stone.SetActive(true);
				stone.transform.position = this.transform.position + this.transform.forward;

				StoneMovement stoneLauncher = stone.GetComponent<StoneMovement>();
				stoneLauncher.Launch(transform.forward);

			} else {
				Debug.Log("No quedan piedras en el inventario");
			}
		}
	}



}
