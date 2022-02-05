using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Transformを最小化する
/// </summary>
public class CloseTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Image").GetComponent<Image>().DOFade(0f, 2f).OnComplete(()=> { transform.DOScale(new Vector2(1f, 0f), 1f); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
