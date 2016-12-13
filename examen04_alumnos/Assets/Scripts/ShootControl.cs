using UnityEngine;
using System.Collections;

public class ShootControl : MonoBehaviour {

	[SerializeField] GameObject bulletPrefab;

	[SerializeField] Transform bulletsPosTr;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Shoot() {
		GameObject bullet = Object.Instantiate(bulletPrefab);
		bullet.transform.position = bulletsPosTr.position;
		//bullet.transform.position = this.transform.position + 
		//			1F * this.transform.forward + 0.4F * this.transform.right;

	}
}
