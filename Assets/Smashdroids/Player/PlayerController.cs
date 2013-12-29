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
        transform.position = ship.transform.position;
		
        if (Input.GetButtonDown("Fire1")) {
            ship.Fire();
        }
    }

}
