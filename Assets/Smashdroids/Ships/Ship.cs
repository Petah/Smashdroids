using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

    public List<GameObject> muzzles;
    public List<GameObject> exhausts;

    public float accelerationForce = 400;
    public float rotationForce = 3000;
    public GameObject exhaust;
    
    public GameObject bullet;
    public float bulletForce = 550;
    public AudioClip shotSound;

    public void Accelerate(float rotation, float acceleration) {
        transform.rigidbody.AddTorque(Vector3.up * rotation * rotationForce);
        transform.rigidbody.AddForce(transform.forward * acceleration * accelerationForce);
        exhaust.particleEmitter.enabled = true;
    }

    public void Fire() {
        foreach (GameObject muzzle in muzzles) {
            GameObject clone = GameObject.Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
            clone.rigidbody.velocity = muzzle.transform.forward * bulletForce;
            AudioSource.PlayClipAtPoint(shotSound, muzzle.transform.position);
        }
    }

}
