using UnityEngine;
using System.Collections;

public abstract class Engine {

    public Transform transform;

    public abstract void Accelerate(float rotation, float acceleration);

}
