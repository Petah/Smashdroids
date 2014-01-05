using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

    public GameObject explosion;
    public AudioClip explosionSound;
 
    public void FixedUpdate() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        float speed = 3;
     
        if (Physics.Raycast(transform.position, forward, out hit, speed)) {
            this.Hit(hit.transform.gameObject, hit.point);
        } else {
            this.transform.Translate(Vector3.forward * speed);
        }
    }
 
    public void Hit(GameObject other, Vector3 position) {
        float power = 5;
        other.SendMessage("Damage", power, SendMessageOptions.DontRequireReceiver);
     
        Instantiate(explosion, position + (Vector3.up * 10), transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
     
        Destroy(gameObject);
    }
 
}
