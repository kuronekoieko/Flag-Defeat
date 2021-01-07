using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HumanController1 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Transform protectedTf;
    [NonSerialized] public bool isFallen;

    private void FixedUpdate()
    {
        if (IsGround())
        {
            Vector3 targetPos = protectedTf.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            if (rb.velocity.sqrMagnitude > 1) return;
            Vector3 vel = transform.forward * 100f;
            vel.y = rb.velocity.y;
            rb.AddForce(vel);
        }
    }

    public void OnInstantiate(Transform protectedTf)
    {
        this.protectedTf = protectedTf;
        transform.forward = -Vector3.forward;
    }

    bool IsGround()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        if (!Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 1f)) return false;
        return hit.collider.transform.CompareTag("Ground");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FallCheck"))
        {
            isFallen = true;
        }
    }
}
