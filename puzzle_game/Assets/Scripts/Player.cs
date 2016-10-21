using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private GameObject nearestButton; 

	[SerializeField] private GameObject[] inventory;
	private int objectCounter;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		inventory = new GameObject[5];
		objectCounter = 0;
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
			SetChildActive (button, "ButtonLight", false);
			SetChildActive (button, "GlimmerLight", false);
			PerformButtonAction(button.name, "hide"); // button.name = "Bridge_Switch"
		} else {
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

	void PerformButtonAction(string buttonName, string action) { // buttonName = "Bridge_Switch"
		string[] targetNameSplitted = buttonName.Split('_');// -> ["Bridge", "Switch"]
		string targetName = targetNameSplitted [0];
		GameObject target = GameObject.Find(targetName + "Animation");
		Animation targetAnim = target.GetComponent<Animation>();
		targetAnim.Play(action + targetName);
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = other.gameObject;
		} else if (other.tag == "Pickable") {
			inventory [objectCounter] = other.gameObject;
			other.gameObject.SetActive (false);
			objectCounter = objectCounter + 1;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Switch" ) {
			this.nearestButton = null;
		}
	}
}