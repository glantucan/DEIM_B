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

	private float dragOnGround;
	private List<Collider> groundContacts;
	[SerializeField] private float jumpSpeed;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		inventory = new GameObject[5];
		objectCounter = 0;
		this.dragOnGround = this.rb.drag;
		this.groundContacts = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

		// ROTATION:
		// -------------------------------------------------------------------------------------------------------------
		// Create the ray starting at the camera with the direction corresponding to the 2D position
		// of the mouse pointer on the screen.
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		// Create a plane, parallel to the ground and at the height of the player gameobject 
		// to intersect the camera ray. This way we avoid inconsitencies produced 
		// by different game object heights in the scene.
		Plane viewPlane = new Plane(Vector3.up, transform.position); 	// 1st paramenter is the vector defining orientation of 
																// the plane. 2nd is just a point the plane must include
        // Define a float to hold the distance to the intersection point
        float rayDistance;
        // Cast the ray from the plane and check if there is an intersection
        if (viewPlane.Raycast(mouseRay, out rayDistance)) {
        	// Get the intersection point between the ray and the plane
            Vector3 intersectionPoint = mouseRay.GetPoint(rayDistance);
            // Draw a line in the editor so we cans see the ray and check 
            // whether it's all right
            Debug.DrawLine(mouseRay.origin, intersectionPoint, Color.green);
            // Finally rotate the player so it looks to the intersection point
            //rotator.rotate(intersectionPoint);
            this.transform.LookAt(intersectionPoint);
        }


		MovePlayer();

		if (this.nearestButton != null) {
			if (Input.GetKeyUp (KeyCode.F)) {
				SwitchButton (this.nearestButton);
			}
		}

		if (Input.GetMouseButtonUp(0)){
			LaunchStoneFromInventory();
		}
	}

	void MovePlayer() {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;

		// v = v0 + a * t
		// s = s0 + v * t

		if( this.direction.magnitude != 0) {
			// this.rb.velocity = this.direction.normalized * this.speed; // Esto no funciona
			// this.rb.velocity = new Vector3 (this.direction.normalized.x * this.speed, this.rb.velocity.y, this.direction.normalized.z * this.speed);
			this.rb.velocity = this.direction.normalized * this.speed + this.rb.velocity.y * Vector3.up;
		}

		if (groundContacts.Count == 0) {
			this.rb.drag = 0;
		} else {
			if (Input.GetKey (KeyCode.Space)) {
				this.rb.velocity = this.direction.normalized * this.speed + jumpSpeed * Vector3.up;
			}
			this.rb.drag = this.dragOnGround;
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
		} 

		if (other.tag == "Pickable") {
			addToInventory (inventory, other.gameObject);
		}

		if (other.tag == "Ground") {
			groundContacts.Add(other);
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
		if (other.tag == "Ground") {
			groundContacts.Remove(other);
		}
	}

}