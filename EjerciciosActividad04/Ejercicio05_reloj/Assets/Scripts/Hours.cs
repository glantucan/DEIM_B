using UnityEngine;
using System.Collections;

public class Hours : MonoBehaviour {

	private int hours;


	public void SetTime(int h) {
		this.hours = h;
		if (this.hours >= 12) {
			this.hours = 0;
		}

		this.SetAngle(this.hours);
	}

	public void IncrementHours() {
		this.hours += 1;
		if (this.hours >= 12) {
			this.hours = 0;
		}

		this.SetAngle(this.hours);
	}

	private void SetAngle(int h) {
		float angle = h * (360/12); 
		this.transform.eulerAngles = new Vector3(0, 0 , angle);
	}
}
