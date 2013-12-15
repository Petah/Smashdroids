using UnityEngine;
using System.Collections;

public class SetupField : MonoBehaviour {

    public GameObject asteroidPrefab;
    public int asteroidCount = 5;
    public float fieldRange = 100;
    private int counter = 0;

    void Update() {
        if (counter < asteroidCount) {
            Vector3 randomPosition = new Vector3(
                Random.Range(-fieldRange, fieldRange),
                0,
                Random.Range(-fieldRange, fieldRange)
            );

            GameObject clone;
            clone = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity) as GameObject;
            clone.transform.parent = transform;

            counter++;
        }
    }

}
