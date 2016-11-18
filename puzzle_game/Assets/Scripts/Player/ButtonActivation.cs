using UnityEngine;
using System.Collections;

public class ButtonActivation : MonoBehaviour {

	private GameObject nearestButton; 

	// Update is called once per frame
	private void Update () {
		if (this.nearestButton != null) {
			if (Input.GetKeyUp (KeyCode.F)) {
				SwitchButton (this.nearestButton);
			}
		}
	}

	private void SwitchButton(GameObject button) {
		if (IsChildActive (button, "ButtonLight")) {
			SetChildActive (button, "ButtonLight", false);
			SetChildActive (button, "GlimmerLight", false);
			PerformButtonAction(button.name, "hide"); // button.name = "Bridge_Switch"
		} else {
			SetChildActive (button, "ButtonLight", true);
			SetChildActive (button, "GlimmerLight", true);
			PerformButtonAction(button.name, "show");
		}
	}

	private bool IsChildActive(GameObject parent, string childName) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject;
		return child.activeSelf;
	}

	private void SetChildActive(GameObject parent, string childName, bool activation) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject; 
		child.SetActive(activation);
	}

	private void PerformButtonAction(string buttonName, string action) { // buttonName = "Bridge_Switch"
		string[] targetNameSplitted = buttonName.Split('_');// -> ["Bridge", "Switch"]
		string targetName = targetNameSplitted [0];
		GameObject target = GameObject.Find(targetName + "Animation");
		Animation targetAnim = target.GetComponent<Animation>();
		targetAnim.Play(action + targetName);
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
