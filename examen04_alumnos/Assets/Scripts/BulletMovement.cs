using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	[SerializeField] private float v;
	private Vector3 direction;
	
	// Update is called once per frame
	private void Update () {
		Vector3 displacement = v * direction * Time.deltaTime;
		this.transform.position += displacement;
	}

	public void SetDirection(Vector3 dir) {
		this.direction = dir;
	}


}
