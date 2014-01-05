using UnityEngine;
using System.Collections;

public class Math {

    public static float Direction(float x1, float y1, float x2, float y2) {
        float direction = Mathf.Atan2(y2 - y1, x2 - x1) * Mathf.Rad2Deg;
        if (direction > 360) {
            direction -= 360;
        }
        if (direction < 0) {
            direction += 360;
        }
        return direction;
    }
 
    public static float Distance(float x1, float y1, float x2, float y2) {
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));
    }

    public static float LengthDirX(float length, float direction) {
        return Mathf.Cos(direction * Mathf.Deg2Rad) * length;
    }

    public static float LengthDirY(float length, float direction) {
        return Mathf.Sin(direction * Mathf.Deg2Rad) * length;
    }

    public static float NormaliseDegrees(float degrees) {
        degrees = degrees % 360;

        if (degrees < 0) {
            degrees += 360;
        }

        return degrees;
    }

}
