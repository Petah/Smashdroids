using UnityEngine;
using System.Collections;

public class SetupField : MonoBehaviour {

	public GameObject asteroidPrefab;
	public int fieldRange = 100;
	public float seed = 100;
	public float accelerationForce = 500;
	public float rotationForce = 500;
	private MersenneTwister random;
	
	public void InitialiseZone(int x, int y) {
		x *= fieldRange;
		y *= fieldRange;
		uint seed = (uint)(x + (1000 * y));
		MersenneTwister random = new MersenneTwister(seed);
		for (var i = 0; i < 5; i++) {
			Vector3 position = new Vector3(
                random.Range(x, x + fieldRange),
                0,
                random.Range(y, y + fieldRange)
            );
			
			Asteroid.SpawnAt(asteroidPrefab, position);
		}
	}
	
	public void Start() {
		InitialiseZone(0, 0);
		InitialiseZone(-1, 0);
		InitialiseZone(0, -1);
		InitialiseZone(-1, -1);
//		while (counter < asteroidCount) {
//
//			GameObject clone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity) as GameObject;
//			//clone.transform.parent = transform;
//			
//			clone.rigidbody.AddForce(
//				random.GenerateFloat() * accelerationForce, 
//				0, 
//				random.GenerateFloat() * accelerationForce
//			);
//			
//			clone.rigidbody.AddTorque(
//				random.GenerateFloat() * rotationForce, 
//				random.GenerateFloat() * rotationForce, 
//				random.GenerateFloat() * rotationForce
//			);
//
//			counter++;
//		}
	}

}
