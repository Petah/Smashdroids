using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

	public Transform muzzle;
	public GameObject bullet;
	public float bulletForce = 150;
	public AudioClip shotSound;
	
	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			GameObject clone = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
			clone.rigidbody.velocity = transform.forward * bulletForce;
			AudioSource.PlayClipAtPoint(shotSound, transform.position);
		}
	}
}
