using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DroneEngine : MonoBehaviour, IEngine
{
    [Header("Engine Properties")]
    [SerializeField] private float maxPower = 4f;

    public void InitEngine()
    {
    }

    public void UpdateEngine(Rigidbody rb, DroneInputs inputs)
    {
        Vector3 engineForce = Vector3.zero;
        engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (inputs.Throttle * maxPower)) / 4f;

        rb.AddForce(engineForce, ForceMode.Force);
    }
}
