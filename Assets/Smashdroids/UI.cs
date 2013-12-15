using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public void OnGUI() {
		GUI.Box(new Rect(10,10,100,90), "Ship Menu");

		if(GUI.Button(new Rect(20,40,80,20), "Weapon 1")) {
			
		}

		if(GUI.Button(new Rect(20,70,80,20), "Weapon 2")) {
		}
	}
	
}
