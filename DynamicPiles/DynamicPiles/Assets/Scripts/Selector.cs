using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
	[SerializeField] private MeshRenderer selectorRend;
	private Color defColor;
	// Use this for initialization
	void Start () {
		defColor = selectorRend.material.color;
	}

	public void Select() {
		selectorRend.material.color = Color.red;
	}

	public void DeSelect() {
		selectorRend.material.color = defColor;
	}

	public bool isSelected() {
		return selectorRend.material.color == Color.red;
	}
}
