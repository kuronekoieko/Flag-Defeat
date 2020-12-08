using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    int defeatCount;
    void Start()
    {

    }

    public void Defeat(Vector3 forward)
    {
        defeatCount++;
        float orientationRate = (float)defeatCount / 3f;
        transform.up = Vector3.Lerp(Vector3.up, forward, orientationRate);
    }
}
