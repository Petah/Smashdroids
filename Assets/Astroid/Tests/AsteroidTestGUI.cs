using UnityEngine;
using System.Collections;

public class AsteroidTestGUI : MonoBehaviour {

    public Asteroid asteroid;

    public void OnGUI() {
        GUI.Box(new Rect(10, 10, 100, 120), "Asteroid");

        int y = 40;
        if (GUI.Button(new Rect(20, y, 80, 20), "Reset")) {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            for (int i = 0; i < asteroids.Length; i ++) {
                Destroy(asteroids[i]);
            }

            Instantiate(asteroid, new Vector3(), Quaternion.identity);
        }

        y += 30;
        if (GUI.Button(new Rect(20, y, 80, 20), "Deform")) {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            for (int i = 0; i < asteroids.Length; i ++) {
                Asteroid asteroid = (Asteroid)(asteroids[i].GetComponent(typeof(Asteroid)));
                asteroid.Deform();
            }
        }

        y += 30;
        if (GUI.Button(new Rect(20, y, 80, 20), "Explode")) {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            for (int i = 0; i < asteroids.Length; i ++) {
                Asteroid asteroid = (Asteroid)(asteroids[i].GetComponent(typeof(Asteroid)));
                asteroid.Explode();
            }
        }
    }

    public void OnDrawGizmos() {
        float size = 1;
        float range = 10;
     
        for (float x = -range; x <= range; x += size) {
            Vector3 start = new Vector3(x, 0, range);
            Vector3 end = new Vector3(x, 0, -range);
            Gizmos.DrawLine(start, end);
        }
        for (float z = -range; z <= range; z += size) {
            Vector3 start = new Vector3(range, 0, z);
            Vector3 end = new Vector3(-range, 0, z);
            Gizmos.DrawLine(start, end);
        }
    }

}
