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

    public void UpdateEngine()
    {
        Debug.Log("Running engine " + gameObject.name);
    }
}
