using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    
    private float health = 20;
    private float size = 1;
    
    // Deform properties
    private float deformAmount = 0.3f;
    private MeshFilter meshfilter;
    private Mesh sourceMesh;
    
    public static void SpawnAt(GameObject astroidPrefab, Vector3 position) {
        if (!Physics.CheckSphere(position, 3)) {
            Instantiate(astroidPrefab, position, Quaternion.identity);
        }
    }
    
    public void Update() {
        if (health < 0) {
            if (transform.localScale.x > 0.2) {
                for (int i = 0; i < 3; i++) {
                    Transform clone = Instantiate(transform, transform.position, Quaternion.identity) as Transform;

                    Vector3 scale = transform.localScale;
                    scale.x /= 2;
                    scale.y /= 2;
                    scale.z /= 2;
                    clone.localScale = scale;
                }
            }
            Destroy(gameObject);
        }
    }

    public void Explode() {
    }
        
    public void Damage(float damage) {
        health -= damage;
    }
    
    public void Start() {
        // Clone mesh assigned to game object
        meshfilter = gameObject.GetComponentInChildren<MeshFilter>();
        sourceMesh = new Mesh();
        sourceMesh = meshfilter.mesh;
        
        Deform();
        
        uint seed = (uint)(
            transform.position.x * 10000 + 
            transform.position.y * 10000 + 
            transform.position.z * 10000
        );
        
        MersenneTwister random = new MersenneTwister();
        
        float min = 500;
        float max = 2000;
        rigidbody.AddForce(
            random.Range(min, max, true), 
            0, 
            random.Range(min, max, true)
        );
        
        float rotationForce = 500;
        rigidbody.AddTorque(
            random.Range(min, max, true), 
            random.Range(min, max, true), 
            random.Range(min, max, true)
        );
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
