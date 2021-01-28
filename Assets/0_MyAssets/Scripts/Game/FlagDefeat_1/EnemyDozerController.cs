using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyDozerController : MonoBehaviour
{
    DozerController1 dozerController;
    [SerializeField] FlagController_1 playerFlag;
    [SerializeField] Transform playerBack;
    Vector3 vel;
    public bool isTargetFlag { get; set; }

    private void Awake()
    {
        dozerController = GetComponent<DozerController1>();
    }

    void Start()
    {
        isTargetFlag = true;
        dozerController.state = DozerState.Waiting;
        DOVirtual.DelayedCall(1f, () =>
        {
            dozerController.state = DozerState.Control;
        });
    }


    void Update()
    {
        if (Variables.screenState != ScreenState.Game) return;
        switch (dozerController.state)
        {
            case DozerState.Control:
                Vector3 target = isTargetFlag ? playerFlag.transform.position : playerBack.position;
                Vector3 a = (target - transform.position);
                a.y = 0;
                vel = a.normalized;
                Debug.Log((vel * 10f - dozerController.rb.velocity) * 20f);
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
