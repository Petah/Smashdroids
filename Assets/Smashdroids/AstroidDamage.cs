using UnityEngine;
using System.Collections;

public class AstroidDamage : MonoBehaviour {
	
	public static GameObject astroid;
	public static float accelerationForce = 500;
	public static float rotationForce = 500;
	private float health = 20;
	private float size = 1;
		
	public static void Generate(MersenneTwister random, Vector3 position) {
		GameObject clone = Instantiate(astroid, position, Quaternion.identity) as GameObject;
		
		clone.rigidbody.AddForce(
			random.GenerateFloat() * accelerationForce, 
			0, 
			random.GenerateFloat() * accelerationForce
		);
		
		clone.rigidbody.AddTorque(
			random.GenerateFloat() * rotationForce, 
			random.GenerateFloat() * rotationForce, 
			random.GenerateFloat() * rotationForce
		);
	}
	
	public void Update() {
		if (health < 0) {
			size /= 2;
			if (size > 0.2) {
				
			}
			Destroy(gameObject);
		}
	}
		
	public void Damage(float damage) {
		health -= damage;
	}
		
}
