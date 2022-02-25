using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DroneInputs : MonoBehaviour
{
    #region Variables

    private Vector2 cyclic;
    private float pedals;
    private float throttle;

    public Vector2 Cyclic { get => cyclic; }
    public float Pedals { get => pedals; }
    public float Throttle { get => throttle; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCyclic(InputValue value)
    {
        cyclic = value.Get<Vector2>();
    }

    private void OnPedals(InputValue value)
    {
        pedals = value.Get<float>();
    }

    private void OnThrottle(InputValue value)
    {
        throttle = value.Get<float>();
    }
}
