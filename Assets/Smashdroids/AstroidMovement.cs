using UnityEngine;
using System.Collections;

public class AstroidMovement : MonoBehaviour {
	
	public float accelerationForce = 50;
	public float rotationForce = 50;
	
	void Update() {
		rigidbody.AddForce(Random.rotation.x * accelerationForce, Random.rotation.y * accelerationForce, Random.rotation.z * accelerationForce);
		rigidbody.AddTorque(Random.rotation.x * rotationForce, Random.rotation.y * rotationForce, Random.rotation.z * rotationForce);
	}
	
}
