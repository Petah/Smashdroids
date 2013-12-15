using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
 
    public Ship ship;

    public void FixedUpdate() {
        float rotation = Input.GetAxis("Horizontal");
        float acceleration = Input.GetAxis("Vertical");
        ship.Accelerate(rotation, acceleration);
    }

    public void Update() {
        if (Input.GetButtonDown("Fire1")) {
            foreach (GameObject muzzle in ship.muzzles) {
                muzzle.GetComponent<Muzzle>().gun.Fire();
            }
        }
        transform.position = ship.transform.position;
    }

}
