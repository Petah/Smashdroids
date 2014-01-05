using UnityEngine;
using System.Collections;

public class DrawAI : MonoBehaviour {

    public void OnDrawGizmos() {
        DrawPlayerDebug(GameObject.FindGameObjectWithTag("Player"));
        foreach (GameObject ai in GameObject.FindGameObjectsWithTag("AI")) {
            DrawAIDebug(ai);
        }
    }

    public void DrawPlayerDebug(GameObject player) {
        // Draw line in player direction
        float direction = -player.transform.eulerAngles.y + 90;
        Gizmos.DrawLine(
            player.transform.position,
            player.transform.position + new Vector3(Math.LengthDirX(10, direction), 0, Math.LengthDirY(10, direction))
        );
    }

    public void DrawAIDebug(GameObject ai) {
        Color color = Color.red;
        color.a = 0.5f;
        Gizmos.color = color;

        Gizmos.DrawWireSphere(ai.transform.position, 1);

        AIShip aiShip = (AIShip) ai.GetComponent(typeof(AIShip));
        if (aiShip.target) {
            // Draw line current direction
            float direction;

            if (aiShip.IsOnTarget()) {
                Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
            } else {
                Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            }

            direction = aiShip.currentDirection - aiShip.targetAngle;
            Gizmos.DrawLine(
                aiShip.transform.position,
                aiShip.transform.position + new Vector3(Math.LengthDirX(10, direction), 0, Math.LengthDirY(10, direction))
            );

            direction = aiShip.currentDirection + aiShip.targetAngle;
            Gizmos.DrawLine(
                aiShip.transform.position,
                aiShip.transform.position + new Vector3(Math.LengthDirX(10, direction), 0, Math.LengthDirY(10, direction))
            );

//            Gizmos.DrawLine(
//                aiShip.transform.position,
//                aiShip.transform.position + new Vector3(Math.LengthDirX(10, 0), 0, Math.LengthDirY(10, 0))
//            );
//            Gizmos.DrawLine(
//                aiShip.transform.position,
//                aiShip.transform.position + new Vector3(Math.LengthDirX(10, 90), 0, Math.LengthDirY(10, 90))
//            );
//            Gizmos.DrawLine(
//                aiShip.transform.position,
//                aiShip.transform.position + new Vector3(Math.LengthDirX(10, 180), 0, Math.LengthDirY(10, 180))
//            );
//            Gizmos.DrawLine(
//                aiShip.transform.position,
//                aiShip.transform.position + new Vector3(Math.LengthDirX(10, 270), 0, Math.LengthDirY(10, 270))
//            );

            // Draw line in target direction
            direction = aiShip.targetDirection;
            Gizmos.DrawLine(
                aiShip.transform.position,
                aiShip.transform.position + new Vector3(Math.LengthDirX(10, direction), 0, Math.LengthDirY(10, direction))
            );

            // Draw sphere around target
            Gizmos.DrawWireSphere(aiShip.target.transform.position, 1);
        }
    }

}
