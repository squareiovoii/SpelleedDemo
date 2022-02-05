using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// デッキのコントローラクラス
/// </summary>
public class DeckController : MonoBehaviour
{
    private void Awake()
    {
        Player.InitPlayerInfo();

        Player.Shuffle(Player.deck);
        for(int i = 0; i < 5; i++)
        {
            Player.cards[i] = Player.deck[0];
            Player.deck.RemoveAt(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // デッキ枚数
        transform.Find("Deck/Text").GetComponent<Text>().text = "×" + Player.deck.Count.ToString();

        // 墓地枚数
        transform.Find("Graveyard/Text").GetComponent<Text>().text = "×" + Player.graveyard.Count.ToString();

        // 次のカードの色
        CardInfo.Colors next = new CardInfo(Player.deck[0]).cardColor;
        if (next == CardInfo.Colors.blue)
        {
            transform.Find("Blue").GetComponent<Image>().DOFade(1f, 0f);
            transform.Find("Yellow").GetComponent<Image>().DOFade(0f, 0f);
            transform.Find("Red").GetComponent<Image>().DOFade(0f, 0f);
        }
        else if (next == CardInfo.Colors.yellow)
        {
            transform.Find("Blue").GetComponent<Image>().DOFade(0f, 0f);
            transform.Find("Yellow").GetComponent<Image>().DOFade(1f, 0f);
            transform.Find("Red").GetComponent<Image>().DOFade(0f, 0f);
        }
        else
        {
            transform.Find("Blue").GetComponent<Image>().DOFade(0f, 0f);
            transform.Find("Yellow").GetComponent<Image>().DOFade(0f, 0f);
            transform.Find("Red").GetComponent<Image>().DOFade(1f, 0f);
        }
    }
}
