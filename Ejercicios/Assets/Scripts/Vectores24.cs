using UnityEngine;
using System.Collections;

public class Vectores24 : MonoBehaviour {

	[SerializeField] private float minV;
	[SerializeField] private float maxV;

	private Vector3 direction;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		direction = Random.onUnitSphere;
		velocity = Random.Range(minV, maxV) * direction;
		Debug.Log("Velocidad de la esfera:" + velocity.magnitude);
		/*Vector3 dir = new Vector3 (Random.Range(-1F, 1F), 
									Random.Range(-1F, 1F), Random.Range(-1F, 1F));
		direction = dir.normalized;*/
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 displacement = velocity * Time.deltaTime;
		transform.position = transform.position + displacement;
	}
}
