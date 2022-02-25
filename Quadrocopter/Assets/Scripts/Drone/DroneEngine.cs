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

    public void UpdateEngine(Rigidbody rb, DroneInputs inputs, bool autoHover)
    {
        float finalDiff; 

        if (autoHover)
        {
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            finalDiff = Physics.gravity.magnitude * diff;
        } 
        else
        {
            finalDiff = 0f;
        }

        Vector3 engineForce = Vector3.zero;
        engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (inputs.Throttle * maxPower)) / 4f;

        rb.AddForce(engineForce, ForceMode.Force);
    }
}
