using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPartController : MonoBehaviour
{
    [SerializeField] DozerController1 dozerController;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        HitDozerBody(other);
        HitDozerAttack(other);
        HitFlag(other);
    }

    void HitDozerBody(Collider other)
    {
        var dozerBody = other.gameObject.GetComponent<DozerController1>();
        if (dozerBody == null) return;
        if (dozerBody == dozerController) return;
        dozerController.AttackBound();
        dozerBody.Broken();
    }

    void HitDozerAttack(Collider other)
    {
        var dozerAttack = other.gameObject.GetComponent<AttackPartController>();
        if (dozerAttack == null) return;
        dozerController.AttackBound();
    }

    void HitFlag(Collider other)
    {
        var flag = other.gameObject.GetComponent<FlagController_1>();
        if (flag == null) return;
        dozerController.AttackBound();
        flag.Defeat(transform.forward, dozerController);
        Debug.Log("旗");
    }

}
