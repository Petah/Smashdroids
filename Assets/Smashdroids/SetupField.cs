using UnityEngine;
using System.Collections;

public class SetupField : MonoBehaviour {

	public GameObject asteroidPrefab;
	public int asteroidCount = 5;
	public float fieldRange = 100;
	public float seed = 100;
	public float accelerationForce = 500;
	public float rotationForce = 500;
	private int counter = 0;
	private MersenneTwister random;
	
	public void InitialiseZone(int x, int y) {
		x += 10000;
		y += 10000;
		uint seed = (uint)(x + (1000 * y));
		MersenneTwister random = new MersenneTwister(seed);
		while (counter < asteroidCount) {
			Vector3 position = new Vector3(
                random.Range(-fieldRange, fieldRange),
                0,
                random.Range(-fieldRange, fieldRange)
            );
			
			Astroid.SpawnAt(position);
		}
		Debug.Log(seed);
	}
	
	public void Start() {
		InitialiseZone(1, 1);
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
