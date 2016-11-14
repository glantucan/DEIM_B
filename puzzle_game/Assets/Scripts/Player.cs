using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private GameObject nearestButton; 

	[SerializeField] private GameObject[] inventory;
	private int objectCounter;

	[SerializeField] private bool isGrounded;
	private float dragOnGround;
	private List<Collider> groundContacts;


	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		inventory = new GameObject[5];
		objectCounter = 0;
		this.isGrounded = true;
		this.dragOnGround = this.rb.drag;
		this.groundContacts = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;

		// v = v0 + a * t
		// s = s0 + v * t

		if( this.direction.magnitude != 0) {
			// this.rb.velocity = this.direction.normalized * this.speed;
			this.rb.velocity = new Vector3 (this.direction.normalized.x * this.speed, this.rb.velocity.y, this.direction.normalized.z * this.speed);
			this.rb.velocity = this.direction.normalized * this.speed + this.rb.velocity.y * Vector3.up;
		}
		if (groundContacts.Count == 0) {
			this.rb.drag = 0;
		} else {
			this.rb.drag = this.dragOnGround;
		}

		if (this.nearestButton != null) {
			if (Input.GetKeyUp (KeyCode.Space)) {
				SwitchButton (this.nearestButton);
			}
		}

		if (Input.GetMouseButtonUp(0)){
			LaunchStoneFromInventory();
		}
	}

	void LaunchStoneFromInventory() {
		if (objectCounter > 0) {
			GameObject stone = inventory[objectCounter-1];
			inventory[objectCounter-1] = null;
			objectCounter = objectCounter - 1;
			stone.SetActive(true);
			stone.transform.position = this.transform.position + this.transform.forward;

			StoneMovement stoneLauncher = stone.GetComponent<StoneMovement>();
			stoneLauncher.Launch(transform.forward);

		} else {
			Debug.Log("No quedan piedras en el inventario");
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
			addToInventory (inventory, other.gameObject);
		}
	}

	void addToInventory( GameObject[] anyInventory, GameObject theObject) {

		if (objectCounter < anyInventory.Length) {
			anyInventory [objectCounter] = theObject;
			theObject.SetActive (false);
			objectCounter = objectCounter + 1;
		} else {
			Debug.Log("No queda sitio en el inventario");
		}
	}



	void OnTriggerExit(Collider other) {
		if(other.tag == "Switch" ) {
			this.nearestButton = null;
		}
	}


	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground") {
			groundContacts.Add(col.collider);
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ground") {
			groundContacts.Remove(col.collider);
		}
	}
}