using UnityEngine;
using System.Collections;

public class Ejercicio5 : MonoBehaviour {

	[SerializeField] Seconds secondsComp;

	private float timeCounter;

	// Use this for initialization
	void Start () {
		secondsComp.SetTime(5, 59, 50);
	}

	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter >= 0.0001F) {
			secondsComp.IncrementSeconds();
			timeCounter = 0F;
		}
	}
}
