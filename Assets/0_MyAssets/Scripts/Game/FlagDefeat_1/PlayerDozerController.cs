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

    private void Start()
    {
        dozerController.state = DozerState.Control;
    }

    void Update()
    {
        if (Variables.screenState != ScreenState.Game) return;
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
                dozerController.rb.AddForce((vel * 13f - dozerController.rb.velocity) * 100f);
                if (vel.sqrMagnitude > 0.1f) transform.forward = vel;
                break;
            case DozerState.Back:
                break;
            default:
                break;
        }


    }
}
