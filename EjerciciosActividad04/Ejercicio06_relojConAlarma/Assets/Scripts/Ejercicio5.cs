using UnityEngine;
using System.Collections;

public class Ejercicio5 : MonoBehaviour {

	[SerializeField] Seconds secondsComp;
	[SerializeField] Alarm alarmComp;

	private float timeCounter;

	// Use this for initialization
	void Start () {
		secondsComp.SetTime(5, 59, 55);
		alarmComp.SetAlarmTime(6,0,0);
	}

	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter >= 1F) {
			secondsComp.IncrementSeconds();
			timeCounter = 0F;

			Debug.Log(secondsComp.GetHour() + ":" + secondsComp.GetMinutes() + ":" + secondsComp.GetSeconds());
		}
	}
}
