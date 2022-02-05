using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// モンスターのコントローラクラス
/// </summary>
public class EnemyController : MonoBehaviour
{
    public static bool isDead;       // 敵を倒したか
    public static bool isPlayerDead; // プレイヤーを倒したか
    public static bool isEncount;
    public static int wave;
    int enemyId = 1;
    private CardInfo cardInfo;
    public static int attackFrameNow;
    public static int attackFrameMax;
    bool isAttackable;                // 攻撃のカウントを減らせるかどうか

    private void Awake()
    {
        // プレイヤー開始時ボイス
        GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player1);

        // Wave1を表示（デモではソードスケルトンを初期敵に設定）
        isDead = false;
        isPlayerDead = false;
        isEncount = false;
        isAttackable = false;
        wave = 1;
        enemyId = 1;

        GameObject.Find("Wave").GetComponent<CanvasGroup>().DOFade(0f, 2f).SetDelay(1f).OnComplete(()=>
        {
            // TODO: 動的にモンスターの声を変更
            GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Enemy1);

            ShowEnemyImage(enemyId);
            attackFrameMax = Enemy.attackFrame;
            attackFrameNow = attackFrameMax;
            isAttackable = true;
            // ソードスケルトンの出現
            //GameObject prefab = (GameObject)Resources.Load("Prefab/Enemy" + enemyId.ToString());
            //Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
            //Enemy.SetEnemyInfo(enemyId);

        });

    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // モンスターを倒した判定
        if (isEncount)
        {
            if(Enemy.nowHp <= 0)
            {
                isEncount = false;

                transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0f, 2f).OnComplete(() =>
                {
                    Destroy(transform.GetChild(0).gameObject);
                    isDead = true;
                    wave += 1;
                    isAttackable = false;
                });
            }
        }

        // モンスター登場判定
        if (isDead && wave == 2)
        {
            // 2Waveのモンスター出現
            enemyId = 2;
            isDead = false;

            // WAVE表示後にモンスター出現
            GameObject.Find("Wave").GetComponent<CanvasGroup>().DOFade(1f, 2f).OnComplete(() =>
            {
                GameObject.Find("Wave").GetComponent<CanvasGroup>().DOFade(0f, 2f).SetDelay(1f).OnComplete(() =>
                {
                    // TODO: 動的にモンスターの声を変更
                    GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Enemy2);

                    ShowEnemyImage(enemyId);
                    attackFrameMax = Enemy.attackFrame;
                    attackFrameNow = attackFrameMax;
                    isAttackable = true;
                    //GameObject prefab = (GameObject)Resources.Load("Prefab/Enemy" + enemyId.ToString());
                    //Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
                    //Enemy.SetEnemyInfo(enemyId);
                });
            });
        }

        if (isDead && wave == 3)
        {
            BgmController.ChangeBgm(3);

            // 3Waveのモンスター出現
            enemyId = 5;
            isDead = false;

            // WAVE表示後にモンスター出現
            GameObject.Find("Wave").GetComponent<CanvasGroup>().DOFade(1f, 2f).OnComplete(() =>
            {
                GameObject.Find("Wave").GetComponent<CanvasGroup>().DOFade(0f, 2f).SetDelay(1f).OnComplete(() =>
                {
                    // TODO: 動的にモンスターの声を変更
                    GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Enemy3);

                    ShowEnemyImage(enemyId);
                    attackFrameMax = Enemy.attackFrame;
                    attackFrameNow = attackFrameMax;
                    isAttackable = true;
                    //GameObject prefab = (GameObject)Resources.Load("Prefab/Enemy" + enemyId.ToString());
                    //Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
                    //Enemy.SetEnemyInfo(enemyId);
                });
            });

        }

        if (isDead && wave > 3)
        {
            isDead = false;
            // TODO: プレイヤー勝利時ボイス
            GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player10);

            // 勝利画面
            GameObject.Find("Win").GetComponent<Transform>().DOScale(1f, 0f).OnComplete(() =>
            {
                GameObject.Find("Win").GetComponent<CanvasGroup>().DOFade(1f,2f);
            });
        }
    }

    /// <summary>
    /// フレームをカウントし、敵の攻撃を実施
    /// </summary>
    private void FixedUpdate()
    {
        if (!isAttackable)
        {
            return;
        }

        attackFrameNow -= 1;
        if (attackFrameNow == 0 && !isPlayerDead　&& !isDead && wave <= 3)
        {
            EnemyAttack();
            attackFrameNow = attackFrameMax;
        }
    }

    /// <summary>
    /// 敵画像のPrefabを生成する
    /// </summary>
    /// <param name="enemyId">エネミーID</param>
    private void ShowEnemyImage(int enemyId)
    {
        GameObject prefab = (GameObject)Resources.Load("Prefab/Enemy" + enemyId.ToString());
        Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, transform);
        Enemy.SetEnemyInfo(enemyId);
    }

    private void EnemyAttack()
    {
        int cardNo;
        if(Enemy.color == new CardInfo(Enemy.cards[0]).cardColor) { cardNo = 0; }
        else if (Enemy.color == new CardInfo(Enemy.cards[1]).cardColor) { cardNo = 1; }
        else if (Enemy.color == new CardInfo(Enemy.cards[2]).cardColor) { cardNo = 2; }
        else if (Enemy.color == new CardInfo(Enemy.cards[3]).cardColor) { cardNo = 3; }
        else if (Enemy.color == new CardInfo(Enemy.cards[4]).cardColor) { cardNo = 4; }
        else
        {
            Enemy.NextColor();
            return;
        }

        // カード処理
        cardInfo = new CardInfo(Enemy.cards[cardNo]);
        ToPlayerEffect();
        cardInfo.UseCard(cardInfo.delegateMethod, CardInfo.User.enemy, cardNo);
        Enemy.NextColor();

        // カードログを表示
        GameObject prefab = (GameObject)Resources.Load("Prefab/AttackLog");
        GameObject obj = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, GameObject.Find("EnemyLog").transform);
        obj.GetComponent<EnemyAttackLog>().msg = cardInfo.cardName + " : " + cardInfo.description;

        // 被弾ボイス再生
        switch (Random.Range(7, 9))
        {
            case 7: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player7); break;
            case 8: GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player8); break;
        }

        // プレイヤーの死亡判定
        if (Player.nowHp <= 0)
        {
            isPlayerDead = true;
            isAttackable = false;
            // TODO: プレイヤー敗北時ボイス
            GameDirector.DoSound(transform, SoundEffectCommon.SoundType.Player9);

            // TODO: BGM切り替え

            // 敗北画面
            GameObject.Find("Lose").GetComponent<Transform>().DOScale(1f, 0f).OnComplete(() =>
            {
                GameObject.Find("Lose").GetComponent<CanvasGroup>().DOFade(1f, 2f);
            });
        }

        // カードを墓地に送り、カードを引く
        Enemy.graveyard.Add(Enemy.cards[cardNo]);
        Enemy.cards[cardNo] = Enemy.deck[0];
        Enemy.deck.RemoveAt(0);
        if (Enemy.deck.Count == 0)
        {
            // 墓地をデッキにしてシャッフル、墓地をリセット
            Enemy.deck = new List<int>(Enemy.graveyard);
            Enemy.Shuffle(Enemy.deck);
            Enemy.graveyard = new List<int>();
        }

    }

    private void ToPlayerEffect()
    {
        //Transform setTransform = transform.parent.parent.Find("UICanvas/ToPlayerEffect");
        Transform setTransform = GameObject.Find("UICanvas/ToPlayerEffect").transform;
        GameObject prefab = (GameObject)Resources.Load("Effects/Effect" + cardInfo.effectId.ToString());

        Instantiate(prefab, setTransform.position, Quaternion.identity, setTransform);

        // エフェクトのサイズによって表示場所を変える
        //if (cardInfo.effectSize == CardInfo.EffectSize.small)
        //{
        //    Instantiate(prefab, setTransform.position, Quaternion.identity, setTransform);
        //}
        //else if (cardInfo.effectSize == CardInfo.EffectSize.medium)
        //{
        //    Instantiate(prefab, new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.75f, 1.5f), 0f), Quaternion.identity, setTransform);
        //}
        //else
        //{
        //    Instantiate(prefab, new Vector3(0f, 1f, 0f), Quaternion.identity, setTransform);
        //}
    }
}
