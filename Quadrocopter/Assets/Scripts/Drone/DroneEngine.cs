using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DroneEngine : MonoBehaviour, IEngine
{
    [Header("Engine Properties")]
    [SerializeField] private float maxPower = 4f;
    [Header("Propeller Properties")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float propellerRotationSpeed = 300f;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance = 0.3f;

    public void InitEngine()
    {
    }

    public void UpdateEngine(Rigidbody rb, DroneInputs inputs, bool autoHover)
    {
        float autoHoverForce; 

        if (autoHover)
        {
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            autoHoverForce = rb.mass * Physics.gravity.magnitude + Physics.gravity.magnitude * diff;
        } 
        else
        {
            autoHoverForce = 0f;
        }

        Vector3 engineForce = Vector3.zero;
        engineForce = transform.up * (autoHoverForce + (inputs.Throttle * maxPower)) / 4f;

        rb.AddForce(engineForce, ForceMode.Force);

        HandlePropellers(inputs.Throttle);
    }

    void HandlePropellers(float throttle)
    {
        if (!propeller)
            return;

        if (throttle != 0)
            propeller.Rotate(Vector3.up, throttle * propellerRotationSpeed);
    }

}
