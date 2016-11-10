/*	
Ejercicio Vectores03:

Posiciona cada cubo en su marcador correspondiente usando vectores 
y teniendo encuenta que el marcador X se encuentra en el origen de coordenadas:

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vectores01 : MonoBehaviour {
	public GameObject cube_x;
	public GameObject cube_1;
	public GameObject cube_2;
	public GameObject cube_3;
	public GameObject cube_4;
	public GameObject cube_5;

	// Use this for initialization
	private void Start () {
		//Ejemplo:
		// cube_3.transform.position = new Vector3 (1, 0, 3);
		// Tambien lo puedes hacer así:
		// cube_3.transform.position = 1*Vector3.right + 3*Vector3.forward;
		// Usando los vectores unidad en las direcciones de los ejes: 
		//   x -> Vector3.right 
		//   y -> Vector3.up 
		//   z -> Vector3.forward 
		// Te recomiendo que lo hagas de las dos maneras por que dependiendo de la situación 
		// es más comodo usar una o otra de las formas
		
	}
}
