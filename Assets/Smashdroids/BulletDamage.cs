using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	public float power = 5;
	public GameObject explosion;
	public AudioClip explosionSound;
	
	public void OnCollisionEnter(Collision other) {
		if (other.gameObject) {
			other.gameObject.SendMessage("Damage", power, SendMessageOptions.DontRequireReceiver);
			
			GameObject clone;
			clone = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			
			Destroy(gameObject);
		}
	}
	
}
