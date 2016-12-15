using UnityEngine;
using System.Collections;

public class ShootControl : MonoBehaviour {

	[SerializeField] private GameObject bulletPrefab;

	[SerializeField] private Transform bulletsPosTr;

	public void Shoot() {
		GameObject bullet = Object.Instantiate(bulletPrefab);
		//bullet.transform.position = this.transform.position + 
		//			1F * this.transform.forward + 0.4F * this.transform.right;
		bullet.transform.position = bulletsPosTr.position;

		BulletMovement bulletControl = bullet.GetComponent<BulletMovement>();
		bulletControl.SetDirection(this.transform.forward);
	}
}
