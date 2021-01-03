using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PushEmAllToy
{
    public enum PlayerState
    {
        Control,
        Back,
    }
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] DynamicJoystick joystick;
        Vector3 vel;
        PlayerState state;
        float controlSpeed = 7f;

        void Start()
        {
            state = PlayerState.Control;
        }


        void Update()
        {

            switch (state)
            {
                case PlayerState.Control:
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
                    break;
                case PlayerState.Back:
                    break;
                default:
                    break;
            }


        }

        private void FixedUpdate()
        {

            switch (state)
            {
                case PlayerState.Control:
                    rb.velocity = vel * 7f;
                    if (vel.sqrMagnitude > 0.1f) transform.forward = vel;
                    break;
                case PlayerState.Back:
                    break;
                default:
                    break;
            }
        }
    }

}
