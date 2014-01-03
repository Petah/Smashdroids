using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
	float repeatTime = 1.0f;
 
	void Start() { 
		RandomRotate();
	}
 
	void  RandomRotate() {
		float goal = Random.Range(90.0f, 270.0f);
		Quaternion desiredAngle = Quaternion.AngleAxis(goal, Vector3.up);
 
		Quaternion startRotation = transform.rotation;
		//If we don't find a start point, we will get an easing effect at the end.
 
		float i = Time.time;   
		transform.rotation = Quaternion.Slerp(startRotation, desiredAngle, i / repeatTime);
 
	}
}
