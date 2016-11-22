using UnityEngine;
using System.Collections;

public class ButtonActivation : MonoBehaviour {

	private GameObject nearestButton; 

	// Update is called once per frame
	private void Update () {
		if (this.nearestButton != null) {
			if (Input.GetKeyUp (KeyCode.F)) {
				ButtonController controller = nearestButton.GetComponent<ButtonController>();
				controller.Interact();
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = other.gameObject;
		} 
	}

	private void OnTriggerExit(Collider other) {
		if(other.tag == "Switch" ) {
			this.nearestButton = null;
		}
	}

}
