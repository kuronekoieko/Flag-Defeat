using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Unityで解像度に合わせて画面のサイズを自動調整する
/// http://www.project-unknown.jp/entry/2017/01/05/212837
/// </summary>
public class CameraController : MonoBehaviour
{
    public static CameraController i;
    Vector3 startPos;
    void Start()
    {
        i = this;
        startPos = transform.position;
    }

    void Update()
    {

    }

    public void Shake()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOShakePosition(duration: 1, strength: 0.3f))
            .Append(transform.DOLocalMove(startPos, 0.5f));
    }
}
