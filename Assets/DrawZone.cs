using UnityEngine;
using System.Collections;

public class DrawZone : MonoBehaviour {

	public void OnDrawGizmos() {
		float size = 2000;
		float range = 10000;
		
		for (float x = -range; x <= range; x += size) {
			Vector3 start = new Vector3(x - 1, 0, range);
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
