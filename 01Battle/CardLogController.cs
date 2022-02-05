using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// カードログのコントローラクラス
/// </summary>
public class CardLogController : MonoBehaviour
{
    private int destroyCount;

    // Start is called before the first frame update
    void Start()
    {
        destroyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.Find("Back/Log").childCount > 0)
        {
            transform.GetComponent<CanvasGroup>().DOFade(0, 0.5f);

            transform.Find("Back/Log").GetChild(0).Find("Active").GetComponent<CanvasGroup>().DOFade(1f, 1f);
            transform.Find("Back/Log").GetChild(0).Find("Inactive").GetComponent<CanvasGroup>().DOFade(0f, 0.5f);

            //transform.Find("Back/Log").GetChild(0).DOScale(1f, 0.5f);
            //transform.Find("Back/Log").GetChild(0).Find("Shade").DOScale(0f, 0.5f);

            destroyCount += 1;

            if(destroyCount > 100)
            {
                Destroy(transform.Find("Back/Log").GetChild(0).gameObject);
                destroyCount = 0;
            }
        }
    }

    /// <summary>
    /// ONボタン時の処理（ログオブジェクトを表示）
    /// </summary>
    public void OnLog()
    {
        transform.Find("Back").DOScale(1f, 0f);
        transform.Find("Swich/On").DOScale(0f, 0f);
        transform.Find("Swich/Off").DOScale(1f, 0f);
    }

    /// <summary>
    /// OFFボタン時の処理（ログオブジェクトを非表示）
    /// </summary>
    public void OffLog()
    {
        transform.Find("Back").DOScale(0f, 0f);
        transform.Find("Swich/On").DOScale(1f, 0f);
        transform.Find("Swich/Off").DOScale(0f, 0f);
    }
}
