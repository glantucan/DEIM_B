using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleMove : MonoBehaviour {

	[SerializeField] float speed;

	private List<Vector3> displacements = new List<Vector3>();
	private int currentIndex;
	private Vector3 currentDisplacement;
	private Vector3 currentTarget;
	private bool isMoving;
	private bool hasStarted;
	private bool hasFinished;
	private int frameCount;

	void Update() {
		frameCount++;
		if (this.hasStarted && !hasFinished) {
			if (this.isMoving) {
				Vector3 distance2Target = (this.currentTarget - this.transform.position);
				if (Mathf.Abs(distance2Target.magnitude) >= this.speed * Time.deltaTime) {
					this.transform.position += this.currentDisplacement.normalized * this.speed * Time.deltaTime;
				} else {
					this.transform.position = this.currentTarget;
					this.isMoving = false;
					tryNextTarget();
				}
			}
		}
	}

	private void tryNextTarget() {
		if(this.displacements.Count > 0) {
			if (!this.isMoving) {
				this.isMoving = true;
				this.currentDisplacement = this.displacements[0];
				this.displacements.Remove(this.currentDisplacement);
				this.currentTarget = this.transform.position + this.currentDisplacement;
				Debug.Log(": Setting new displacement: " + this.currentDisplacement);
			}
		} else {
			hasFinished = true;
			Debug.Log(": You have reached the final point!!!");
			/*Debug.LogWarning("You have set an initial position but I don't see any Move commands");*/
		}
	}

	public void SetInitialPosition(Vector3 initialPos) {
		currentTarget = transform.position = initialPos;
		if (isMoving) {
			Debug.LogWarning("You should not set an initial position if the cube is moving!");
		} else {
			hasStarted = true;
			isMoving = true;
		} 
	}

	public void Move(Vector3 displacement) {
		displacements.Add(displacement);
	}
}