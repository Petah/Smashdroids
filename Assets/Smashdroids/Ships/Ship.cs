using UnityEngine;//
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

    public List<GameObject> muzzles;
    public List<GameObject> exhausts;

    public float accelerationForce = 400;
    public float rotationForce = 3000;
    public float maxSpeed = 100;
    public GameObject exhaust;
    
    public GameObject bullet;
    public float bulletForce = 550;
    public AudioClip shotSound;
	
    public GameObject thrusterSound;

    public void Accelerate(float rotation, float acceleration) {
        transform.rigidbody.AddTorque(Vector3.up * rotation * rotationForce);
        transform.rigidbody.AddForce(transform.forward * acceleration * accelerationForce);
		
		if (rigidbody.velocity.magnitude > maxSpeed) {
           rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
		
        exhaust.particleEmitter.enabled = true;
		
		float volume = Mathf.Abs(rotation) + acceleration;
		
		this.thrusterSound.audio.volume = volume;
		if (volume > 0.01) {
			if (!this.thrusterSound.audio.isPlaying) {
				this.thrusterSound.audio.Play();
			}
		} else {
			if (this.thrusterSound.audio.isPlaying) {
				this.thrusterSound.audio.Stop();
			}
		}
    }

    public void Fire() {
        foreach (GameObject muzzle in muzzles) {
            GameObject.Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
			muzzle.audio.clip = shotSound;
			muzzle.audio.Play();
        }
    }

}
