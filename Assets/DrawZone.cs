using UnityEngine;
using System.Collections;

public class DrawZone : MonoBehaviour {
	
	public float zoneSize = 1;
	public float range = 100;

	public void OnDrawGizmos() {
		for (float x = -range; x < range; x += zoneSize) {
			Vector3 start = new Vector3(x, 0, range);
			Vector3 end = new Vector3(x, 0, -range);
			Gizmos.DrawLine(start, end);
		}
		for (float z = -range; z < range; z += zoneSize) {
			Vector3 start = new Vector3(range, 0, z);
			Vector3 end = new Vector3(-range, 0, z);
			Gizmos.DrawLine(start, end);
		}
	}
}
