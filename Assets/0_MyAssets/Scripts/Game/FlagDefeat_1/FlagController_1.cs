using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController_1 : MonoBehaviour
{
    [SerializeField] DozerController1 masterDozer;
    int defeatCount;
    int maxDefeatCount = 3;
    void Start()
    {

    }

    public void Defeat(Vector3 forward, DozerController1 dozer)
    {
        if (Variables.screenState != ScreenState.Game) return;
        if (dozer == masterDozer) return;
        defeatCount++;
        float orientationRate = (float)defeatCount / (float)maxDefeatCount;
        transform.up = Vector3.Lerp(Vector3.up, forward, orientationRate);
        if (defeatCount != maxDefeatCount) return;

        if (masterDozer.IsPlayer)
        {
            Variables.screenState = ScreenState.Failed;
        }
        else
        {
            Variables.screenState = ScreenState.Clear;
        }
    }
}
