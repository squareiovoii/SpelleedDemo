using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// ジョーカーカードのコントローラクラス
/// </summary>
public class CardJokerController : MonoBehaviour
{
    private int cardId = 0;
    private CardInfo cardInfo;
    private Vector3 originPosition;
    private bool isActive;
    public static int nowRecast;

    private void Awake()
    {
        // ジョーカーのリキャスト回数
        nowRecast = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        originPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        isActive = true;

        ReloadCard();
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
        if (!isActive) { return; };                          // 処理中の場合
        if (nowRecast > 0) { return; }                       // リキャストタイムが0より大きい場合
        if (!EnemyController.isEncount) { return; }          // 敵が出現していない場合

        // カードを非アクティブ
        isActive = false;

        // カード処理
        cardInfo.UseCard(cardInfo.delegateMethod, CardInfo.User.player);
        Player.AddUseCount(cardInfo.cardId);
        nowRecast = cardInfo.recast;

        // 色の更新
        Player.NextColor();

        // TODO: 必殺技ボイス再生
        switch (Random.Range(6, 7))
        {
            case 6: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player6); break;
        }

        // エフェクトを再生
        ToEnemyEffect();

        //// カードの動き
        transform.DOMoveY(1f, 0.5f).SetRelative();
        transform.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(() =>
        {
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
        cardId = Player.joker;
        cardInfo = new CardInfo(cardId);

        // カードの見た目を変更
        transform.Find("CardImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/Card" + cardId.ToString());

        if (transform.Find("Frame/Name") != null)
        {
            transform.Find("Frame/Name").GetComponent<Text>().text = cardInfo.cardName;
            transform.Find("Frame/Description").GetComponent<Text>().text = cardInfo.description;
            transform.Find("Frame/Damage/Text").GetComponent<Text>().text = cardInfo.value;
        }
    }

    /// <summary>
    /// プレイヤーの色と比較してカードの明るさを変更する
    /// </summary>
    private void CardLightness()
    {
        if (isActive && nowRecast <= 0)
        {
            transform.Find("Shadow").GetComponent<Image>().DOFade(0f, 0f);
        }
        else
        {
            transform.Find("Shadow").GetComponent<Image>().DOFade(0.6f, 0f);
        }
    }

    /// <summary>
    /// モンスターに対する攻撃エフェクトを表示する
    /// </summary>
    private void ToEnemyEffect()
    {
        Transform setTransform = transform.parent.parent.parent.Find("ToEnemyEffect");
        GameObject prefab = (GameObject)Resources.Load("Effects/Effect" + cardInfo.effectId.ToString());

        // エフェクトのサイズによって表示場所を変える
        if (cardInfo.effectSize == CardInfo.EffectSize.small)
        {
            Instantiate(prefab, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 2.5f), 0f), Quaternion.identity, setTransform);
        }
        else if (cardInfo.effectSize == CardInfo.EffectSize.medium)
        {
            Instantiate(prefab, new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.75f, 1.5f), 0f), Quaternion.identity, setTransform);
        }
        else
        {
            Instantiate(prefab, new Vector3(0f, 1.75f, 0f), Quaternion.identity, setTransform);
        }
    }
}
