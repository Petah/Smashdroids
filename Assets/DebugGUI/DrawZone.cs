using UnityEngine;
using System.Collections;

public class DrawZone : MonoBehaviour {

    public void OnDrawGizmos() {
        DrawGrid(1, 10);
        DrawGrid(10, 100);
        DrawGrid(100, 1000);
    }

    public void DrawGrid(float size, float range) {
        Color color = Color.gray;
        color.a = 0.5f;

        Gizmos.color = color;

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
