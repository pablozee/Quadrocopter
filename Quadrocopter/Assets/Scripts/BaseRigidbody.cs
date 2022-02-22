using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseRigidbody : MonoBehaviour
{
    [Header("Rigidbody Properties")]
    [SerializeField] private float weightInLbs = 1f;

    const float lbsToKg = 0.454f;

    protected Rigidbody rb;
    protected float startDrag;
    protected float startAngularDrag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.mass = weightInLbs * lbsToKg;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb)
            return;

        HandlePhysics();

    }

    protected virtual void HandlePhysics()
    {

    }
}
