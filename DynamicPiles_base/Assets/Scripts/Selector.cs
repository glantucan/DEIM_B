using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	[SerializeField] private MeshRenderer selectionRenderer;

	private Color defColor;

	// Use this for initialization
	private void Start () {
		defColor = selectionRenderer.material.color;
	}
	
	public void Select() {
		selectionRenderer.material.color = Color.red;
	}

	public void Deselect() {
		selectionRenderer.material.color = defColor;
	}
}
