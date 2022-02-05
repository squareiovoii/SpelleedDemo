using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// モンスターのアタックログコントローラクラス
/// </summary>
public class EnemyAttackLog : MonoBehaviour
{
    private int destroyCount;
    public string msg = "";

    // Start is called before the first frame update
    void Start()
    {
        destroyCount = 0;
        transform.Find("EnemyImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("EnemyIcons/EnemyIcon" + Enemy.enemyId.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Text").GetComponent<Text>().text = msg;

        destroyCount += 1;

        // 300フレーム後、オブジェクトを削除
        if (destroyCount > 300)
        {
            transform.GetComponent<CanvasGroup>().DOFade(0f, 1f).OnComplete(()=> { Destroy(transform.gameObject); });
        }
    }
}
