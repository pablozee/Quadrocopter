using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(DroneInputs))]
public class DroneController : BaseRigidbody
{
    [Header("Drone Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;
    [SerializeField] private float lerpSpeed = 2f;
    [SerializeField] private bool autoHover = false;

    private DroneInputs input;
    private List<IEngine> engines = new List<IEngine>();
    private float yaw;
    private float finalPitch;
    private float finalRoll;
    private float finalYaw;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<DroneInputs>();
        engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
    }

    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControls();
    }

    protected virtual void HandleEngines()
    {
    //    rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));

        foreach(IEngine engine in engines)
        {
            engine.UpdateEngine(rb, input, autoHover);
        }
    }

    protected virtual void HandleControls()
    {
        float pitch = input.Cyclic.y * minMaxPitch;
        float roll = -input.Cyclic.x * minMaxRoll;
        yaw += input.Pedals * yawPower;

        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

        Quaternion rotation = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
        rb.MoveRotation(rotation);
    }
}
