using UnityEngine;
using System.Collections;

public class Seconds : MonoBehaviour {

	private int seconds;
	[SerializeField] Minutes minutesComponent;

	public void SetTime(int h, int m, int s) {
		this.seconds = s;
		this.SetAngle(this.seconds);
		minutesComponent.SetTime(h, m);
	}

	public void IncrementSeconds() {
		this.seconds += 1;
		if(this.seconds >= 60) {
			this.seconds = 0;
			this.minutesComponent.IncrementMinutes();
		}
		this.SetAngle(this.seconds);
	}

	private void SetAngle(int s) {
		float angle = s * (360/60); 
		this.transform.eulerAngles = new Vector3(0, 0 , angle);
	}

	public int GetHour() {
		return minutesComponent.GetHours();
	}

	public int GetMinutes() {
		return minutesComponent.GetMinutes();
	}

	public int GetSeconds() {
		return this.seconds;
	}
}
