using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// NEXT COLORボタンのコントローラクラス
/// </summary>
public class NextTurn : MonoBehaviour
{
    private int countdown = 5 * 60;
    private bool isActive;
    private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isHaveColor())
        {
            // 動作中でない場合、ポップアップを表示
            if (!isMove) { transform.DOScale(1f, 1f); }
            countdown -= 1;

            if(countdown > 0)
            {
                transform.Find("Text").GetComponent<Text>().text = "NEXT COLOR ・・・ " + Count(countdown).ToString() + "s";
            }
            else
            {
                transform.Find("Text").GetComponent<Text>().text = "NEXT COLOR";
                isActive = true;

                // ポップアップを大小にして強調
                if (!isMove)
                {
                    isMove = true;
                    transform.DOScale(1.1f, 1f).OnComplete(() =>
                    {
                        transform.DOScale(1.0f, 1f).OnComplete(()=> { isMove = false; });
                    });
                }
            }
        }
        else
        {
            transform.DOScale(0f, 1f);
            countdown = 5 * 60;
            isActive = false;
        }
    }

    private int Count(float frame)
    {
        return (int)(frame / 60);
    }

    /// <summary>
    /// 色のカードを持っているかどうか
    /// </summary>
    /// <returns>true: 持っている, false:持っていない</returns>
    private bool isHaveColor()
    {
        if(new CardInfo(Player.cards[0]).cardColor != Player.color &&
           new CardInfo(Player.cards[1]).cardColor != Player.color &&
           new CardInfo(Player.cards[2]).cardColor != Player.color &&
           new CardInfo(Player.cards[3]).cardColor != Player.color &&
           new CardInfo(Player.cards[4]).cardColor != Player.color)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void NextTurnButton()
    {
        if (isActive)
        {
            Player.NextColor();
            countdown = 5 * 60;
            isActive = false;
        }
    }
}
