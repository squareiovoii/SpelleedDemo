using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// カードのコントローラクラス
/// </summary>
public class CardController : MonoBehaviour
{
    // 左から何番目のカードか
    public int cardNo;
    private int cardId = 0;
    private CardInfo cardInfo;
    private Vector3 originPosition;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = new Vector3(transform.position.x, transform.position.y,0f);
        isActive = true;        

        ReloadCard();
        // ランダムに色を設定
        switch (Random.Range(1, 4))
        {
            case 1: Player.color = CardInfo.Colors.blue; break;
            case 2: Player.color = CardInfo.Colors.yellow; break;
            case 3: Player.color = CardInfo.Colors.red; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReloadCard();
        CardLightness();
    }

    /// <summary>
    /// カードクリック時の処理
    /// </summary>
    public void ClickCard()
    {
        if (!isActive) { return;  };                         // 処理中の場合
        if (!EnemyController.isEncount) { return; }          // 敵が出現していない場合
        if (cardInfo.cardColor != Player.color) { return; };  // 色が違う場合

        // カードを非アクティブ
        isActive = false;

        // カード処理
        cardInfo.UseCard(cardInfo.delegateMethod, CardInfo.User.player, cardNo);
        Player.AddUseCount(cardInfo.cardId);

        // 色の更新
        Player.NextColor();

        // ジョーカーのリキャスト回数を減らす
        CardJokerController.nowRecast -= 1;

        // TODO: ちょっともっさり感があるため再検討
        //// カードの動き（ダイナミック）
        //transform.DOMove(new Vector3(-5f, 2f, 0f), 1f);
        //transform.DOScale(1.5f, 1f);
        //transform.DORotate(new Vector3(0f ,360, 0f), 1f).SetRelative();
        //transform.GetComponent<CanvasGroup>().DOFade(0, 1f).SetDelay(1f).OnComplete(()=>
        //{
        //    // カードを墓地に送る
        //    Player.graveyard.Add(Player.cards[cardNo]);

        //    // カードを引く
        //    Player.cards[cardNo] = Player.deck[0];
        //    Player.deck.RemoveAt(0);
        //    if(Player.deck.Count == 0)
        //    {
        //        // 墓地をデッキにしてシャッフル、墓地をリセット
        //        Player.deck = new List<int>(Player.graveyard);
        //        Player.Shuffle(Player.deck);
        //        Player.graveyard = new List<int>();
        //    }

        //    isActive = true;

        //    transform.DOScale(0.75f, 0f);
        //    transform.DOMove(new Vector3(originPosition.x, originPosition.y -1f), 0f);
        //    transform.DOMoveY(1f, 1f).SetRelative();
        //    transform.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        //});

        // TODO: ログを表示

        // 攻撃ボイス再生
        switch (Random.Range(2, 6))
        {
            case 2: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player2); break;
            case 3: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player3); break;
            case 4: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player4); break;
            case 5: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player5); break;
        }

        // エフェクトを再生
        ToEnemyEffect();

        //// カードの動き
        transform.DOMoveY(1f, 0.5f).SetRelative();
        transform.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(() =>
        {
            // カードを墓地に送る
            Player.graveyard.Add(Player.cards[cardNo]);

            // カードを引く
            Player.cards[cardNo] = Player.deck[0];
            Player.deck.RemoveAt(0);
            if (Player.deck.Count == 0)
            {
                // 墓地をデッキにしてシャッフル、墓地をリセット
                Player.deck = new List<int>(Player.graveyard);
                Player.Shuffle(Player.deck);
                Player.graveyard = new List<int>();
            }

            isActive = true;

            transform.DOMove(new Vector3(originPosition.x, originPosition.y - 1f), 0f);
            transform.DOMoveY(1f, 1f).SetRelative();
            transform.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        });
    }

    /// <summary>
    /// 手札のカードが変更された場合、カード情報を更新する
    /// </summary>
    private void ReloadCard()
    {
        // カードの表示を変更
        if (cardId != Player.cards[cardNo])
        {
            cardId = Player.cards[cardNo];
            cardInfo = new CardInfo(cardId);

            // カードの見た目を変更
            transform.Find("CardImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/Card" + cardId.ToString());

            if(transform.Find("Frame/Name") != null)
            {
                transform.Find("Frame/Name").GetComponent<Text>().text = cardInfo.cardName;
                transform.Find("Frame/Description").GetComponent<Text>().text = cardInfo.description;
                transform.Find("Frame/Damage/Text").GetComponent<Text>().text = cardInfo.value;
            }

            // カードの色を変更
            if (cardInfo.cardColor == CardInfo.Colors.blue)
            {
                transform.Find("Color").DOScale(0.3f, 0f);
                transform.Find("Color/Blue").DOScale(1f, 0f);
                transform.Find("Color/Yellow").DOScale(0f, 0f);
                transform.Find("Color/Red").DOScale(0f, 0f);
            }
            else if (cardInfo.cardColor == CardInfo.Colors.yellow)
            {
                transform.Find("Color").DOScale(0.3f, 0f);
                transform.Find("Color/Blue").DOScale(0f, 0f);
                transform.Find("Color/Yellow").DOScale(1f, 0f);
                transform.Find("Color/Red").DOScale(0f, 0f);
            }
            else if (cardInfo.cardColor == CardInfo.Colors.red)
            {
                transform.Find("Color").DOScale(0.3f, 0f);
                transform.Find("Color/Blue").DOScale(0f, 0f);
                transform.Find("Color/Yellow").DOScale(0f, 0f);
                transform.Find("Color/Red").DOScale(1f, 0f);
            }
            else
            {
                transform.Find("Color").DOScale(0f, 0f);
            }
        }
    }

    /// <summary>
    /// プレイヤーの色と比較してカードの明るさを変更する
    /// </summary>
    private void CardLightness()
    {
        // 色が一致する場合にカード色を明るく
        if (cardInfo.cardColor == CardInfo.Colors.blue)
        {
            if (Player.color == CardInfo.Colors.blue)
            {
                transform.Find("Color/Blue").GetComponent<Image>().DOFade(1f, 0f);
                transform.Find("Shadow").GetComponent<Image>().DOFade(0f, 0f);
            }
            else
            {
                //transform.Find("Color/Blue").GetComponent<Image>().DOFade(0.4f, 0f);
                if (isActive) { transform.Find("Shadow").GetComponent<Image>().DOFade(0.6f, 0f); }
            }
        }
        else if (cardInfo.cardColor == CardInfo.Colors.yellow)
        {
            if (Player.color == CardInfo.Colors.yellow)
            {
                transform.Find("Color/Yellow").GetComponent<Image>().DOFade(1f, 0f);
                transform.Find("Shadow").GetComponent<Image>().DOFade(0f, 0f);
            }
            else
            {
                //transform.Find("Color/Yellow").GetComponent<Image>().DOFade(0.4f, 0f);
                if (isActive) { transform.Find("Shadow").GetComponent<Image>().DOFade(0.6f, 0f); }
            }
        }
        else if (cardInfo.cardColor == CardInfo.Colors.red)
        {
            if (Player.color == CardInfo.Colors.red)
            {
                transform.Find("Color/Red").GetComponent<Image>().DOFade(1f, 0f);
                transform.Find("Shadow").GetComponent<Image>().DOFade(0f, 0f);
            }
            else
            {
                //transform.Find("Color/Red").GetComponent<Image>().DOFade(0.4f, 0f);
                if (isActive) { transform.Find("Shadow").GetComponent<Image>().DOFade(0.6f, 0f); }
            }
        }
    }


    private void ToEnemyEffect()
    {
        Transform setTransform = transform.parent.parent.parent.Find("ToEnemyEffect");
        GameObject prefab = (GameObject)Resources.Load("Effects/Effect" + cardInfo.effectId.ToString());

        // エフェクトのサイズによって表示場所を変える
        if(cardInfo.effectSize == CardInfo.EffectSize.small)
        {
            Instantiate(prefab, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 2.5f), 0f), Quaternion.identity, setTransform);
        }
        else if(cardInfo.effectSize == CardInfo.EffectSize.medium)
        {
            Instantiate(prefab, new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.75f, 1.5f), 0f), Quaternion.identity, setTransform);
        }
        else
        {
            Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, setTransform);
        }
    }
}
