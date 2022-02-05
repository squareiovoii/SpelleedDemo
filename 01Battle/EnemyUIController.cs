using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// モンスターUIのコントローラクラス
/// </summary>
public class EnemyUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // エンカウント状態の場合のみUIを更新
        if (EnemyController.isEncount)
        {
            transform.Find("EnemyHP").DOScale(1f, 0.5f);
            transform.Find("EnemyHP/Bar").GetComponent<Image>().fillAmount = (float)Enemy.nowHp / (float)Enemy.maxHp;

            transform.Find("EnemyName").DOScale(1f, 0.5f);
            transform.Find("EnemyName/Text").GetComponent<Text>().text = Enemy.enemyName;

            transform.Find("EnemyAttack").DOScale(1f, 0.5f);
            transform.Find("EnemyAttack/Counter").GetComponent<Image>().fillAmount = (float)EnemyController.attackFrameNow / (float)EnemyController.attackFrameMax;

            //　現在の色を表示
            if (Enemy.color == CardInfo.Colors.blue)
            {
                transform.Find("EnemyAttack/NowColor/Blue").GetComponent<Image>().DOFade(1f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Red").GetComponent<Image>().DOFade(0f, 0.5f);
            }
            else if (Enemy.color == CardInfo.Colors.yellow)
            {
                transform.Find("EnemyAttack/NowColor/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Yellow").GetComponent<Image>().DOFade(1f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Red").GetComponent<Image>().DOFade(0f, 0.5f);
            }
            else
            {
                transform.Find("EnemyAttack/NowColor/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
                transform.Find("EnemyAttack/NowColor/Red").GetComponent<Image>().DOFade(1f, 0.5f);
            }

            ShowCardColor(1);
            ShowCardColor(2);
            ShowCardColor(3);
            ShowCardColor(4);
            ShowCardColor(5);
        }
        else
        {
            transform.Find("EnemyHP").DOScale(0f, 0.5f);
            transform.Find("EnemyName").DOScale(0f, 0.5f);
            transform.Find("EnemyAttack").DOScale(0f, 0.5f);
        }
    }

    /// <summary>
    /// 敵のカード色を表示する
    /// </summary>
    /// <param name="no">カード番号(1-5)</param>
    private void ShowCardColor(int no)
    {
        CardInfo.Colors cardColor = new CardInfo(Enemy.cards[no-1]).cardColor;
        if (cardColor == CardInfo.Colors.blue)
        {
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Blue").GetComponent<Image>().DOFade(1f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Red").GetComponent<Image>().DOFade(0f, 0.5f);
        }
        else if (cardColor == CardInfo.Colors.yellow)
        {
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Yellow").GetComponent<Image>().DOFade(1f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Red").GetComponent<Image>().DOFade(0f, 0.5f);
        }
        else
        {
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("EnemyAttack/Color" + no.ToString() + "/Red").GetComponent<Image>().DOFade(1f, 0.5f);
        }
    }
}
