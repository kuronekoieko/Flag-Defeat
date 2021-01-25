using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDozerController : MonoBehaviour
{
    DynamicJoystick joystick;
    DozerController1 dozerController;
    Vector3 vel;

    private void Awake()
    {
        joystick = FindObjectOfType<DynamicJoystick>();
        dozerController = GetComponent<DozerController1>();
    }

    void Update()
    {

        switch (dozerController.state)
        {
            case DozerState.Control:
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
                // dozerController.rb.velocity = vel * 20f;
                dozerController.rb.AddForce((vel * 17f - dozerController.rb.velocity) * 20f);
                if (vel.sqrMagnitude > 0.1f) transform.forward = vel;
                break;
            case DozerState.Back:
                break;
            default:
                break;
        }


    }
}
