using UnityEngine;
using System.Collections;

public class AsteroidTestGUI : MonoBehaviour {

    public Asteroid asteroid;

    public void OnGUI() {
        GUI.Box(new Rect(10, 10, 100, 90), "Asteroid");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Deform")) {
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Explode")) {
        }
    }
}
