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
        HitDozerBody(other);
        HitDozerAttack(other);
        HitFlag(other);
    }

    void HitDozerBody(Collision other)
    {
        var dozerBody = other.gameObject.GetComponent<DozerController1>();
        dozerController.AttackBound();
        dozerBody.Broken();
    }

    void HitDozerAttack(Collision other)
    {
        var dozerAttack = other.gameObject.GetComponent<AttackPartController>();
        dozerController.AttackBound();
    }

    void HitFlag(Collision other)
    {
        var flag = other.gameObject.GetComponent<FlagController>();
        dozerController.AttackBound();
        flag.Defeat(transform.forward);
    }

}
