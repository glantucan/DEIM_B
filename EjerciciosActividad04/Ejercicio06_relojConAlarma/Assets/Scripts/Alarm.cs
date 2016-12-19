using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {
	[SerializeField] Seconds secondsComponent;
	private int alarmHours;
	private int alarmMinutes;
	private int alarmSeconds;

	public void SetAlarmTime(int h, int m, int s) {
		this.alarmHours = h;
		this.alarmMinutes = m;
		this.alarmSeconds = s;
	}


	private void Update () {
		int currentSecond = secondsComponent.GetSeconds();
		int currentMinute = secondsComponent.GetMinutes();
		int currentHour = secondsComponent.GetHour();
		if (currentHour == alarmHours) {
			if (currentMinute == alarmMinutes) {
				if(currentSecond == alarmSeconds) {
					Debug.Log ("ALARMAAAAAAA!");
				}
			}
		}
	}	
}
