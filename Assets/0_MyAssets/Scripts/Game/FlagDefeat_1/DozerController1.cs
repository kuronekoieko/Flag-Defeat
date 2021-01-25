using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DozerController1 : MonoBehaviour
{
    public Rigidbody rb;

    [NonSerialized] public DozerState state;
    [SerializeField] ParticleSystem brokenPs;
    float controlSpeed = 15f;

    PlayerDozerController playerDozerController;
    EnemyDozerController enemyDozerController;

    private void Awake()
    {
        playerDozerController = GetComponent<PlayerDozerController>();
        enemyDozerController = GetComponent<EnemyDozerController>();
    }

    void Start()
    {
        state = DozerState.Control;
    }

    public void AttackBound()
    {
        if (playerDozerController) CameraController.i.Shake();
        state = DozerState.Back;
        float backSpeed = 15f;
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
        brokenPs.transform.parent = null;
        brokenPs.transform.position = transform.position;
        brokenPs.Play();
        gameObject.SetActive(false);
    }
}
