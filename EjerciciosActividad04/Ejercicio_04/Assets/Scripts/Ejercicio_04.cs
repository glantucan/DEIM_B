using UnityEngine;
using System.Collections;

public class Ejercicio_04 : MonoBehaviour {

	private int cubosCounter;
	[SerializeField] private GameObject cubePrefab;
	[SerializeField] private float cubeSeparation;
	private GameObject[] cubosArrays;


	// Use this for initialization
	private void Start () {
	
		this.cubosCounter = 0;

		this.cubosArrays = new GameObject[10];

		while (this.cubosCounter < 10){
				
			GameObject cubeInstance = Object.Instantiate (cubePrefab);
			cubeInstance.name = "cube_" + this.cubosCounter;

			this.cubosArrays [this.cubosCounter] = cubeInstance;
			cubeInstance.transform.position = this.cubosCounter * Vector3.right * (cubeSeparation + 1F);

			if ( this.cubosCounter < cubosArrays.Length - 1) {
				CuboMovement cubeMover = this.cubosArrays[this.cubosCounter].GetComponent<CuboMovement>();
				cubeMover.SetTargetPosition(cubeInstance.transform.position + 2F*Vector3.right);
				if( this.cubosCounter > 0 ){
					CuboMovement previousCubeMover = this.cubosArrays[this.cubosCounter - 1].GetComponent<CuboMovement>();
					previousCubeMover.SetTarget(cubeInstance);
				}
			}

			this.cubosCounter += 1;
		}

		CuboMovement firstMover = this.cubosArrays [0].GetComponent<CuboMovement> ();
		firstMover.StartMove ();
	}
}
