using UnityEngine;
using System.Collections;

public class EngineGTR250 : Engine {

    public float accelerationForce = 500;
    public float rotationForce = 3000;
 
    public override void Accelerate(float rotation, float acceleration) {
        transform.rigidbody.AddTorque(Vector3.up * rotation * rotationForce);
        transform.rigidbody.AddForce(transform.forward * acceleration * accelerationForce);
    }
 
}
