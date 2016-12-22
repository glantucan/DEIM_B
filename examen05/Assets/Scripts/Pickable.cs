using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {
	[SerializeField] private string id;

	public string GetId() {
		return id;
	}
}
