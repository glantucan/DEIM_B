using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private GameObject nearestButton; 

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;
		if( this.direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}

		if (nearestButton != null) {
			if (Input.GetKeyUp (KeyCode.Space)) {
				SwitchButton (nearestButton);
			}
		}
	}

	void SwitchButton(GameObject button) {
		if (IsChildActive (button, "ButtonLight")) {
			/*DeActivateChild (button, "ButtonLight");
			DeActivateChild (button, "GlimmerLight");*/
			SetChildActive (button, "ButtonLight", false);
			SetChildActive (button, "GlimmerLight", false);
			PerformButtonAction(button.name, "hide");
		} else {
			/*ActivateChild (button, "ButtonLight");
			ActivateChild (button, "GlimmerLight");*/
			SetChildActive (button, "ButtonLight", true);
			SetChildActive (button, "GlimmerLight", true);
			PerformButtonAction(button.name, "show");
		}
	}

	bool IsChildActive(GameObject parent, string childName) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject;
		return child.activeSelf;
	}

	void SetChildActive(GameObject parent, string childName, bool activation) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject; 
		child.SetActive(activation);
	}

	/*void ActivateChild(GameObject parent, string childName) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject; 
		child.SetActive(true);
	}

	void DeActivateChild(GameObject parent, string childName) {
		Transform childTr = parent.transform.Find(childName);
		GameObject child = childTr.gameObject; 
		child.SetActive(false);
	}*/

	void PerformButtonAction(string buttonName, string action) {
		string[] targetNameSplitted = buttonName.Split('_');
		string targetName = targetNameSplitted [0];
		Debug.Log ("nombre del target: " + targetName);
		GameObject target = GameObject.Find(targetName + "Animation");
		Animation targetAnim = target.GetComponent<Animation>();
		targetAnim.Play(action + targetName);
	}



	void OnTriggerEnter(Collider other) {
		Debug.Log("He entrado en el trigger de un " + other.tag);
		if(other.tag == "Switch" ) {
			this.nearestButton = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		Debug.Log("He salido en el trigger");
		if(other.tag == "Switch" ) {
			this.nearestButton = null;
		}
	}
}
