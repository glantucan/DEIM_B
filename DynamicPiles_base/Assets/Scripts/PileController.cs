using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PileController : MonoBehaviour {

	[SerializeField] private GameObject prefab;
	[SerializeField] private Transform pileATr;
	[SerializeField] private Transform pileBTr;

	private List<GameObject> pileAList;
	private List<GameObject> pileBList;
	private float timer;
	private float timerReset;

	private bool selectionActive;

	private int selectedIndex;

	// Use this for initialization
	private void Start () {
		pileAList = new List<GameObject>();
		pileBList = new List<GameObject>();
		timerReset = 1F;
		timer = timerReset;
		selectedIndex = 0;
		selectionActive = false;
	}
	
	// Update is called once per frame
	private void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0F) {
			pileAList.Add( Object.Instantiate(prefab) );
			pileAList[pileAList.Count - 1].transform.position = Vector3.up * (pileAList.Count - 0.5F) + pileATr.position;
			timer = timerReset;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			if(pileAList.Count > 0) {
				Selector selectedCube = pileAList[selectedIndex].GetComponent<Selector>();
				if (selectionActive) {
					selectedCube.Deselect();
				} else {
					selectedCube.Select();
				}
				selectionActive = !selectionActive;
			}
		} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (selectionActive) {
				if (selectedIndex < pileAList.Count - 1){
					Selector prevCube = pileAList[selectedIndex].GetComponent<Selector>();
					prevCube.Deselect();
					selectedIndex += 1;
					Selector selectedCube = pileAList[selectedIndex].GetComponent<Selector>();
					selectedCube.Select();
				}
			}
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (selectionActive) {
				if (selectedIndex > 0){
					Selector prevCube = pileAList[selectedIndex].GetComponent<Selector>();
					prevCube.Deselect();
					selectedIndex -= 1;
					Selector selectedCube = pileAList[selectedIndex].GetComponent<Selector>();
					selectedCube.Select();
				}
			}
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			if (selectionActive) {
				pileBList.Add(pileAList[selectedIndex]);
				pileAList[selectedIndex].transform.position = pileBTr.position + (pileBList.Count - 0.5f)*Vector3.up;
				pileAList.RemoveAt(selectedIndex);

				if (selectedIndex >= pileAList.Count) {
					selectedIndex -= 1;
				} 
				if (pileAList.Count != 0) {
					Selector selectedCube = pileAList[selectedIndex].GetComponent<Selector>();
					selectedCube.Select();
				} else {
					selectionActive = false;
				}
			}
		}
	}
}
