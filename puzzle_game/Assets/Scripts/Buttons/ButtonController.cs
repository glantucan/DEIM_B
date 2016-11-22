using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	[SerializeField] private GameObject buttonLight;
	[SerializeField] private GameObject buttonGlimmerLight;
	private bool isActive;
	[SerializeField] private GameObject target;

	private ITarget targetAction;

	private void Start() {
		this.targetAction = target.GetComponent<ITarget>();

		Debug.Log(this.targetAction);
		this.isActive = false;
	}

	public void Interact() {
		if (this.isActive){
			this.Deactivate();
			this.isActive = false;
			this.targetAction.UndoAction();
		} else {
			this.Activate();
			this.isActive = true;
			this.targetAction.DoAction();
		}
	}

	private void Activate() {
		this.buttonLight.SetActive(true);
		this.buttonGlimmerLight.SetActive(true);
	}

	private void Deactivate() {
		this.buttonLight.SetActive(false);
		this.buttonGlimmerLight.SetActive(false);
	}


}
