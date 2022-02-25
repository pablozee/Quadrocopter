using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(DroneInputs))]
public class DroneController : BaseRigidbody
{
    [Header("Drone Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minxMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;

    private DroneInputs input;
    private List<IEngine> engines = new List<IEngine>();

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
            engine.UpdateEngine();
        }
    }

    protected virtual void HandleControls()
    {

    }
}
