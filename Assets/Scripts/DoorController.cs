using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]private bool isOpen;
    public float doorVelocity;
    public float doorForce;
    private HingeJoint hinge;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
        isOpen = false;

        JointLimits limits = hinge.limits;
        limits.min = Mathf.Round(hinge.limits.min);
        limits.max = Mathf.Round(hinge.limits.max);
        hinge.limits = limits;
        hinge.useLimits = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            JointMotor motor = hinge.motor;
            motor.targetVelocity = doorVelocity;
            motor.force = doorForce;
            hinge.motor = motor;

            Debug.Log("Hinge:" + Mathf.Round(hinge.angle));
            if (hinge.limits.max == Mathf.Round(hinge.angle))
            {
                rb.isKinematic = true;
            }
        }
        else
        {
            JointMotor motor = hinge.motor;
            motor.targetVelocity = -doorVelocity;
            motor.force = doorForce;
            hinge.motor = motor;

            Debug.Log("Hinge:" + Mathf.Round(hinge.angle));
            if (hinge.limits.min == Mathf.Round(hinge.angle))
            {
                rb.isKinematic = true;
            }
        }        
    }

    [ContextMenu("Open Door")]
    public void OpenDoor()
    {
        isOpen = true;
        rb.isKinematic = false;
    }

    [ContextMenu("Closed Door")]
    public void ClosedDoor()
    {
        isOpen = false;
        rb.isKinematic = false;
    }
}
