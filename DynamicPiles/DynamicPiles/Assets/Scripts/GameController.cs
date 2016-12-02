using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	private List<GameObject> pileAList;
	private List<GameObject> pileBList;

	[SerializeField] private GameObject pileA;
	[SerializeField] private GameObject pileB;

	private float timer;
	private float timerMax;
	[SerializeField] private GameObject cubePrefab;
	private int selected;

	// Use this for initialization
	void Start () {
		pileAList = new List<GameObject>();
		pileBList= new List<GameObject>();
		timerMax = 2F;
		timer = timerMax;
		selected = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.Space)) {
			if (pileAList.Count > 0) {
				if (selected >= pileAList.Count) {
					selected = pileAList.Count - 1;
				}
				pileAList[selected].GetComponent<Selector>().Select();
			}
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			
			if (selected < pileAList.Count - 1) {
				pileAList[selected].GetComponent<Selector>().DeSelect();
				selected += 1;
				pileAList[selected].GetComponent<Selector>().Select();
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			
			if (selected > 0) {
				pileAList[selected].GetComponent<Selector>().DeSelect();
				selected -= 1;
				pileAList[selected].GetComponent<Selector>().Select();
			}
		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			if (pileAList.Count > 0) {
				if(pileAList[selected].GetComponent<Selector>().isSelected()) {
					pileAList[selected].transform.position = pileB.transform.position + (pileBList.Count + 0.5F)*Vector3.up;
					pileBList.Add(pileAList[selected]);
					pileAList.RemoveAt(selected);
					if(selected > 0 ) selected--;

				}
			}
		}

		if (timer <= 0F) {
			timer = timerMax;
			pileAList.Add(Object.Instantiate(cubePrefab));
			pileAList[pileAList.Count - 1].transform.position = 
					pileA.transform.position + (pileAList.Count - 0.5F)*Vector3.up;
		}
	}
}
