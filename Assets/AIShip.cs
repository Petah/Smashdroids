using UnityEngine;
using System.Collections;

public class AIShip : MonoBehaviour {

    public GameObject target;
    public float targetDirection;
    public float currentDirection;
    public float targetAngle = 5;

    public bool IsOnTarget() {
        return Mathf.Abs(currentDirection - targetDirection) < targetAngle;
    }

    private void FindTarget() {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start() {
        FindTarget();
    }

    public void FixedUpdate() {
        float acceleration = 1;

        // Move forward
        float targetDistance = Math.Distance(
            transform.position.x,
            transform.position.z,
            target.transform.position.x,
            target.transform.position.z
        );

        if (targetDistance > 5) {
            float accelerationForce = 70;
            float maxSpeed = 100;
            rigidbody.AddForce(transform.forward * acceleration * accelerationForce);
            if (rigidbody.velocity.magnitude > maxSpeed) {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }
        }

        // Rotate
        float rotation;

        currentDirection = Math.NormaliseDegrees(-transform.eulerAngles.y + 90);
        targetDirection = Math.NormaliseDegrees(Math.Direction(
            transform.position.x,
            transform.position.z,
            target.transform.position.x,
            target.transform.position.z
        ));

        float directionDifference = Math.NormaliseDegrees(currentDirection - targetDirection);

        if (directionDifference > targetAngle &&
                directionDifference < 180 - targetAngle) {
            rotation = 1;
        } else if (directionDifference >= 180 &&
                directionDifference < 360 - targetAngle) {
            rotation = -1;
        } else {
            rotation = 0;
        }

        if (rotation != 0) {
            float rotationForce = 50;
            rigidbody.AddTorque(Vector3.up * rotation * rotationForce);
        }
    }
}
