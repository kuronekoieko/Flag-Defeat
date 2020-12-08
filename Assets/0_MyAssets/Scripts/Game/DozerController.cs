using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] DynamicJoystick joystick;
    Vector3 vel;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            vel = Vector3.zero;
            vel.x = joystick.Horizontal;
            vel.z = joystick.Vertical;
        }
        else
        {
            vel = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = vel * 7f;
        if (vel.sqrMagnitude > 0.1f) transform.forward = vel;
    }
}
