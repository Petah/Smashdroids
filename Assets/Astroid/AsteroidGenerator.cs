using UnityEngine;
using System.Collections;

public class AstroidGenerator : MonoBehaviour {
	
	private float deformAmount = 0.3f;
	private MeshFilter meshfilter;
	private Mesh sourceMesh;
		
	public void OnGUI() {
		if (GUI.Button(new Rect(10, 70, 50, 30), "Deform")) {
			Deform();
		}
	}
	
	public void Start() {
		// Clone mesh assigned to game object
		meshfilter = gameObject.GetComponentInChildren<MeshFilter>();
		sourceMesh = new Mesh();
		sourceMesh = meshfilter.mesh;
	}
	
	private static Mesh CloneMesh(Mesh mesh) {
		Mesh clone = new Mesh();
		clone.vertices = mesh.vertices;
		clone.normals = mesh.normals;
		clone.tangents = mesh.tangents;
		clone.triangles = mesh.triangles;
		clone.uv = mesh.uv;
		return clone;
	}
	
	public void Deform() {
		Mesh deformedMesh = CloneMesh(sourceMesh);
		
		// Deform working mesh
		Vector3[] vertices = deformedMesh.vertices;
		for (int i = 0; i < vertices.Length; i++) {
			Vector3 newPosition = new Vector3();
			newPosition.x = vertices[i].x + Random.Range(-deformAmount, deformAmount);
			newPosition.y = vertices[i].y + Random.Range(-deformAmount, deformAmount);
			newPosition.z = vertices[i].z + Random.Range(-deformAmount, deformAmount);
			for (int j = 0; j < vertices.Length; j++) {
				if (i == j) {
					continue;
				}
				if (vertices[i] == vertices[j]) {
					vertices[j] = newPosition;
				}
			}
			vertices[i] = newPosition;
		}
		deformedMesh.vertices = vertices;
		
		// Apply Laplacian Smoothing filter to mesh
		Mesh workingMesh = CloneMesh(deformedMesh);
		workingMesh.vertices = SmoothFilter.hcFilter(deformedMesh.vertices, workingMesh.vertices, workingMesh.triangles, 0.0f, 0.5f);
		workingMesh.vertices = SmoothFilter.hcFilter(deformedMesh.vertices, workingMesh.vertices, workingMesh.triangles, 0.0f, 0.5f);
		
		workingMesh.RecalculateBounds();
		workingMesh.RecalculateNormals();
		
		meshfilter.mesh = workingMesh;
	}
	
}
