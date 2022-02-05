using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// トランスフォームのコントローラクラス
/// </summary>
/// <remarks>アタッチしたトランスフォームをポップアップする</remarks>
public class PopTransform : MonoBehaviour
{
    public float scale;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(scale, interval).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
