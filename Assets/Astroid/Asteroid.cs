using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    
    private float health = 20;
    
    private Mesh deformedMesh;
    
    public static void SpawnAt(GameObject astroidPrefab, Vector3 position) {
        if (!Physics.CheckSphere(position, 3)) {
            Instantiate(astroidPrefab, position, Quaternion.identity);
        }
    }
    
    public void Update() {
        if (health < 0) {
            if (transform.localScale.x > 0.2) {
                Explode();
            } else {
                Destroy(gameObject);
            }
        }
    }

    public void Explode() {
        int children = 3;
        for (int i = 0; i < children; i++) {
            float positionAround = (2 * Mathf.PI / children) * i;

            Transform clone = Instantiate(transform, transform.position, Quaternion.identity) as Transform;

            Vector3 scale = transform.localScale;
            scale.x /= 2;
            scale.y /= 2;
            scale.z /= 2;
            clone.localScale = scale;

            clone.transform.position = transform.position + new Vector3(Mathf.Cos(positionAround), 0, Mathf.Sin(positionAround));

            clone.rigidbody.AddExplosionForce(100, transform.position, 100);
        }
        Destroy(gameObject);
    }
        
    public void Damage(float damage) {
        health -= damage;
    }
    
    public void Start() {
        Deform();
        
        uint seed = (uint)(
            transform.position.x * 10000 + 
            transform.position.y * 10000 + 
            transform.position.z * 10000
        );
        
        MersenneTwister random = new MersenneTwister(seed);
        
        float min = 5;
        float max = 20;
        rigidbody.AddForce(
            random.Range(min, max, true), 
            0, 
            random.Range(min, max, true)
        );
        
        rigidbody.AddTorque(
            random.Range(min, max, true), 
            random.Range(min, max, true), 
            random.Range(min, max, true)
        );
    }

    public void OnDestroy() {
        Destroy(deformedMesh);
    }

    public void Deform() {
        MeshFilter meshFilter = gameObject.GetComponentInChildren<MeshFilter>();
        deformedMesh = meshFilter.mesh;

        // Deform working mesh
        float deformAmount = 0.7f;
        Vector3[] vertices = deformedMesh.vertices;
        bool[] moved = new bool[vertices.Length];
        for (int i = 0; i < vertices.Length; i++) {
            if (moved[i]) {
                continue;
            }
            Vector3 newPosition = new Vector3();
            newPosition.x = vertices[i].x + Random.Range(-deformAmount, deformAmount);
            newPosition.y = vertices[i].y + Random.Range(-deformAmount, deformAmount);
            newPosition.z = vertices[i].z + Random.Range(-deformAmount, deformAmount);
            for (int j = 0; j < vertices.Length; j++) {
                if (i == j || moved[j]) {
                    continue;
                }
                if (vertices[i] == vertices[j]) {
                    moved[j] = true;
                    vertices[j] = newPosition;
                }
            }
            moved[i] = true;
            vertices[i] = newPosition;
        }
        
        // Apply Laplacian Smoothing filter to mesh
        Vector3[] workingVertices = deformedMesh.vertices;
        int[] workingTriangles = deformedMesh.triangles;
        deformedMesh.vertices = SmoothFilter.hcFilter(vertices, workingVertices, workingTriangles, 0.0f, 0.5f);
        deformedMesh.triangles = workingTriangles;

        deformedMesh.RecalculateBounds();
        deformedMesh.RecalculateNormals();
    }
        
}
