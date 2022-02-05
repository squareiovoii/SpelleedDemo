using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードクラス
/// </summary>
public class CardInfo
{
    /// <summary>
    /// カードの色
    /// </summary>
    public enum Colors
    {
        blue,
        yellow,
        red,
        all
    }

    /// <summary>
    /// カードの分類
    /// </summary>
    public enum Type
    {
        common,
        saint,
        demons,
        joker
    }

    /// <summary>
    /// カードのレアリティ
    /// </summary>
    public enum Rarity
    {
        plain,
        jack,
        queen,
        king,
        joker
    }

    ///// <summary>
    ///// カードの効果分類
    ///// </summary>
    //public enum Effect
    //{
    //    attack,
    //    cure,
    //    buff,
    //    debuff,
    //    change,
    //    jamming
    //}

    /// <summary>
    /// エフェクトのサイズ
    /// </summary>
    public enum EffectSize
    {
        small,
        medium,
        large
    }

    /// <summary>
    /// カードの使用者
    /// </summary>
    public enum User
    {
        player,
        enemy
    }

    public int cardId;                           // カードID
    public string cardName;                      // カード名
    public string description;                   // 効果
    public Colors cardColor;                     // 色
    public int cost;                             // コスト
    public string value;                         // カードに記載する値
    public Type cardType;                        // カードのタイプ（ジョーカー,デモンズ,セイント,コモン）
    public Rarity cardRarity;                    // レアリティ
    public int effectId;                         // エフェクトID
    public EffectSize effectSize;                // エフェクトの大きさ
    public int recast;                           // ジョーカーの場合のリキャストカード回数
    public delegate void Delegate(User user, int cardNo);             // デリゲート
    public Delegate delegateMethod = (User user, int cardNo) => { };  // カード効果の処理

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">カードID</param>
    public CardInfo(int id)
    {
        cardId = id;
        SetColorInfo(cardId);

        switch (cardId)
        {
            // 1-3: ナックル
            case 1: case 2: case 3:
                cardName = "ナックル";
                description = "相手に1ダメージ";
                cost = 1;
                value = "1";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 1;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 1); };
                break;
            // 4-6: ブレイククロー
            case 4: case 5: case 6:
                cardName = "ブレイブクロー";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 1;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 7-9: 地砕き
            case 7: case 8: case 9:
                cardName = "地砕き";
                description = "相手に3ダメージ";
                cost = 3;
                value = "3";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 1;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 3); };
                break;
            // 10-12: 強斬撃
            case 10: case 11: case 12:
                cardName = "強斬撃";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 101;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 13-15: ファイヤ
            case 13: case 14: case 15:
                cardName = "ファイヤ";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 2;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 16-18: アイス
            case 16: case 17: case 18:
                cardName = "アイス";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 7;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 19-21: サンダー
            case 19: case 20: case 21:
                cardName = "サンダー";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 5;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 22-24: 地崩れ
            case 22: case 23: case 24:
                cardName = "地崩れ";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 6;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;
            // 25-27: トリプルアロー
            case 25: case 26: case 27:
                cardName = "トリプルアロー";
                description = "相手に3回ランダムな威力(0-2)で攻撃";
                cost = 2;
                value = "X";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 8;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) =>
                {
                    ToDamage(user, Random.Range(0, 3));
                    ToDamage(user, Random.Range(0, 3));
                    ToDamage(user, Random.Range(0, 3));
                };
                break;
            // 28-30: ランダムアロー
            case 28: case 29: case 30:
                cardName = "ランダムアロー";
                description = "相手にランダムな威力(0-5)で攻撃";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 1;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, Random.Range(0, 6)); };
                break;

            // 31-33: エナジーソード／敵にダメージを与えてHPを回復
            // 34-36: エンチャントソード／使用回数に応じて威力が上がる
            // 37-39: カードリロード／手札をシャッフルする
            // 40-42: カラーリロード／手札のカード色をランダムに変更
            // 43-45: 補給物資／HPを1回復
            // 46-48: 医療物資／HPを2回復
            // 49-51: キュア／HPを3回復
            // 52-54: 青の輝き／敵の色を青に変更
            // 55-57: 黄の輝き／敵の色を黄に変更
            // 58-60: 赤の輝き／敵の色を赤に変更
            // 61-63: 凶暴化／次の攻撃のダメージ2倍
            // 64-66: 不意打ち使用回数が少ないほどダメージ増加
            // 67-69: 敵に5ダメージ, 自分に1ダメージ
            // 70-72: ???／ランダムな量回復
            // 73-75:
            // 76-78:
            // 79-81:
            // 82-84:
            // 85-87:

            // TODO: 敵の攻撃
            // 88-90:ひっかき
            case 88: case 89: case 90:
                cardName = "ひっかき";
                description = "相手に1ダメージ";
                cost = 1;
                value = "1";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 103;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 1); };
                break;

            // 91-93:かみつき
            case 91: case 92: case 93:
                cardName = "かみつき";
                description = "相手に2ダメージ";
                cost = 2;
                value = "2";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 104;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 2); };
                break;

            // 94-96: 大薙ぎ
            case 94: case 95: case 96:
                cardName = "大薙ぎ";
                description = "相手に3ダメージ";
                cost = 3;
                value = "3";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 105;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 3); };
                break;

            // 97-99: ドラゴンブレス
            case 97: case 98: case 99:
                cardName = "ドラゴンブレス";
                description = "相手に5ダメージ";
                cost = 5;
                value = "5";
                cardType = Type.common;
                cardRarity = Rarity.plain;
                effectId = 102;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 5); };
                break;

            // 101: 天界の裁き
            case 101:
                cardName = "天界の裁き";
                description = "相手に3ダメージを与える";
                cardColor = Colors.all;
                cost = 3;
                value = "3";
                cardType = Type.joker;
                cardRarity = Rarity.joker;
                effectId = 202;
                effectSize = GetEffectSize(effectId);
                recast = GetRecast(cost);
                delegateMethod = (User user, int cardNo) => { ToDamage(user, 3); };
                break;

                // 墓地のカードが多いほどダメージ増加
                // 墓地のカードが少ないほどダメージ増加
                // 〜秒間ダメージ軽減
                // 同色カードを捨てる
        }
    }

    /// <summary>
    /// 色の情報をセットする
    /// </summary>
    /// <param name="id"></param>
    private void SetColorInfo(int id)
    {
        switch (id % 3)
        {
            case 1: cardColor = Colors.blue; break;
            case 2: cardColor = Colors.yellow; break;
            default: cardColor = Colors.red; break;
        }
    }

    /// <summary>
    /// 各インスタンスに設定したデリゲートを実行するメソッド
    /// </summary>
    /// <param name="method">スキル毎に設定したデリゲート変数</param>
    /// <param name="method">カード番号</param>
    public void UseCard(Delegate method, User user, int cardNo = 0)
    {
        delegateMethod(user, cardNo);
    }

    /// <summary>
    /// 敵にダメージを与える
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    private void ToDamage(User user, int damage)
    {
        if(user == User.player)
        {
            Enemy.nowHp -= damage;
        }
        else
        {
            Player.nowHp -= damage;
        }
    }

    /// <summary>
    /// HPを回復する
    /// </summary>
    /// <param name="value">回復量</param>
    private void CureHp(User user, int value)
    {

    }

    /// <summary>
    /// 番号のカードをトラッシュする
    /// </summary>
    /// <param name="cardNo">カード番号</param>
    private void TrashCard(User user, int cardNo)
    {
        // カードを捨てる処理
        // カードを引く処理
        // カードを捨てるエフェクト
    }

    /// <summary>
    /// 自分の色を変更する
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cardNo"></param>
    private void ChangeMyColor(User user,int cardNo, Colors color)
    {

    }

    /// <summary>
    /// 相手の色を変更する
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cardNo"></param>
    private void ChangeYourColor(User user,int cardNo, Colors color)
    {

    }

    /// <summary>
    /// エフェクトのIDに応じたエフェクトサイズを返す
    /// </summary>
    /// <param name="id">エフェクトID</param>
    /// <returns>エフェクトサイズ</returns>
    private EffectSize GetEffectSize(int id)
    {
        if(0 <= id && id < 100)
        {
            return EffectSize.small;
        }
        else if(id < 200)
        {
            return EffectSize.medium;
        }
        else
        {
            return EffectSize.large;
        }
    }

    /// <summary>
    /// コストに応じたリキャスト回数を返す
    /// </summary>
    /// <param name="id">エフェクトID</param>
    /// <returns>エフェクトサイズ</returns>
    private int GetRecast(int cost)
    {
        switch (cost)
        {
            case 1: return 4;
            case 2: return 7;
            case 3: return 10;
            case 4: return 13;
            case 5: return 16;
            case 6: return 19;
            case 7: return 21;
            case 8: return 24;
            case 9: return 27;
            case 10: return 30;
            default: return 30;
        }
    }
}
