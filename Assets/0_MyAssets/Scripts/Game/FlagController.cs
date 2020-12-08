using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    int defeatCount;
    int maxDefeatCount = 3;
    void Start()
    {

    }

    public void Defeat(Vector3 forward)
    {
        if (Variables.screenState != ScreenState.Game) return;
        defeatCount++;
        float orientationRate = (float)defeatCount / (float)maxDefeatCount;
        transform.up = Vector3.Lerp(Vector3.up, forward, orientationRate);
        if (defeatCount != maxDefeatCount) return;
        Variables.screenState = ScreenState.Clear;
    }
}
