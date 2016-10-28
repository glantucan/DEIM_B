using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	[SerializeField] GameObject target;
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float v;

	private int frameCounter;
	private GameObject bulletInstance;

	void Start() {
		this.frameCounter = 0;
	}

	void Update() {
		
		if (frameCounter % 20 == 0) {
			bulletInstance = Object.Instantiate (bulletPrefab);
			bulletInstance.transform.position = this.transform.position +
				2F * this.transform.forward + 1.1F * this.transform.up;
			Vector3 distanceToTarget = this.target.transform.position - this.transform.position;
			Vector3 direction = distanceToTarget.normalized;
			Vector3 velocityVector = v * direction;
		}



		if (bulletInstance != null) {
			bulletInstance.transform.position = 
						bulletInstance.transform.position + velocityVector * Time.deltaTime;
		}

		this.frameCounter = this.frameCounter + 1;
	}

	
}
