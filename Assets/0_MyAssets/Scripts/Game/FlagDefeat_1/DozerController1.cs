using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DozerController1 : MonoBehaviour
{
    public Rigidbody rb;

    [NonSerialized] public DozerState state;
    float controlSpeed = 7f;

    void Start()
    {
        state = DozerState.Control;
    }

    public void AttackBound()
    {
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
    }


    public void Broken()
    {

    }
}
