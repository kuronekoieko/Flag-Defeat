using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum DozerState
{
    Waiting,
    Control,
    Back,
}
public class DozerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] DynamicJoystick joystick;
    Vector3 vel;
    DozerState state;
    float controlSpeed = 7f;

    void Start()
    {
        state = DozerState.Control;
    }


    void Update()
    {

        switch (state)
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
                break;
            case DozerState.Back:
                break;
            default:
                break;
        }


    }

    private void FixedUpdate()
    {

        switch (state)
        {
            case DozerState.Control:
                rb.velocity = vel * 7f;
                if (vel.sqrMagnitude > 0.1f) transform.forward = vel;
                break;
            case DozerState.Back:
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var flag = other.gameObject.GetComponent<FlagController>();
        if (flag == null) return;
        CameraController.i.Shake();
        state = DozerState.Back;
        float backSpeed = 10f;
        Vector3 dir = -transform.forward;
        DOTween.To(() => backSpeed, (x) => backSpeed = x, 0, 0.7f)
        .SetEase(Ease.Linear)
        .OnUpdate(() =>
        {
            rb.velocity = dir * backSpeed;
            transform.forward = -dir;
        })
        .OnComplete(() =>
        {
            state = DozerState.Control;
        });

        flag.Defeat(transform.forward);
    }
}
