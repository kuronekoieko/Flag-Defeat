using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSliderController : MonoBehaviour
{
    [SerializeField] HumanManager1 humanManager;
    [SerializeField] Slider slider;

    void Start()
    {
        // slider.minValue = 0;
        // slider.maxValue = humanManager.HumanCount();
    }

    void Update()
    {
        slider.value = (float)humanManager.FallCount() / (float)humanManager.HumanCount();
        if (humanManager.FallCount() < humanManager.HumanCount()) return;
        if (Variables.screenState != ScreenState.Game) return;
        Variables.screenState = ScreenState.Clear;
        Debug.Log(Variables.screenState);
    }
}
