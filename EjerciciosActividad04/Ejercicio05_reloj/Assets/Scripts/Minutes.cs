using UnityEngine;
using System.Collections;

public class Minutes : MonoBehaviour {

	private int minutes;
	[SerializeField] Hours hoursComponent;

	public void SetTime(int h, int m) {
		this.minutes = m;
		this.SetAngle(this.minutes);
		hoursComponent.SetTime(h);
	}

	public void IncrementMinutes() {
		this.minutes += 1;
		if(this.minutes >= 60) {
			this.minutes = 0;
			this.hoursComponent.IncrementHours();
		}
		this.SetAngle(this.minutes);
	}

	private void SetAngle(int m) {
		float angle = m * (360/60); 
		this.transform.eulerAngles = new Vector3(0, 0 , angle);
	}
}
