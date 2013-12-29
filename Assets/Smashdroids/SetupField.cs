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
	
	public void Start() {
		random = new MersenneTwister(1);
		while (counter < asteroidCount) {
			Vector3 randomPosition = new Vector3(
                random.Range(-fieldRange, fieldRange),
                0,
                random.Range(-fieldRange, fieldRange)
            );

			GameObject clone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity) as GameObject;
			//clone.transform.parent = transform;
			
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

			counter++;
		}
	}

}
