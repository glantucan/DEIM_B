using UnityEngine;
using System.Collections;

public class CuboMovement : MonoBehaviour {

	private Vector3 targetPosition;
	private GameObject target;
	private int v;
	private bool isStopped;

	// Update is called once per frame
	private void Update () {
		if (!isStopped) {
			Vector3 desplazamiento = this.v * Vector3.right* Time.deltaTime;
			this.transform.position += desplazamiento;
			Vector3 distance2Target = this.targetPosition - this.transform.position;

			if ( distance2Target.magnitude <= this.v*Time.deltaTime) {
				StopMove();
				this.transform.position = this.targetPosition;
				if (this.target != null) {
					CuboMovement nextMover = this.target.GetComponent<CuboMovement>();
					nextMover.StartMove();
					isStopped = true;
				}
			}
		}
	}

	public void SetTargetPosition(Vector3 theTargetPosition){
		this.targetPosition = theTargetPosition;

	}
	public void SetTarget(GameObject thetarget) {
		this.target = thetarget;
	}

	public void StartMove (){
		if (this.targetPosition != Vector3.zero){
			this.v = 4;
		}
	}

	private void StopMove (){
		this.v = 0;
	}
}
