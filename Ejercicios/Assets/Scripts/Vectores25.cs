using UnityEngine;
using System.Collections;

public class Vectores25 : MonoBehaviour {

	[SerializeField] private Transform sphereTr;
	private Vector3 firstPos;
	private float firstTime;
	private Vector3 measuredVel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount == 10) {
			firstPos = sphereTr.position;
			firstTime = Time.time;
		} else if (Time.frameCount == 30) {
			Vector3 distance = sphereTr.position - firstPos;
			measuredVel = distance/ (Time.time - firstTime);
		} else if (Time.frameCount == 60) {
			Debug.Log("Velocidad medida:" + measuredVel.magnitude);
		}
	}
}
