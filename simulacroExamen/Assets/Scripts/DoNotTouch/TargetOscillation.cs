using UnityEngine;
using System.Collections;

public class TargetOscillation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(
			20F*Mathf.Sin(Mathf.Deg2Rad*(Mathf.PI + Time.time *45F)), 
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
