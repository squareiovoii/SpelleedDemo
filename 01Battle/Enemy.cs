using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスタークラス
/// </summary>
public static class Enemy
{
    public static int enemyId;
    public static string enemyName;

    // ヒットポイント
    public static int maxHp;
    public static int nowHp;

    // 現在の色
    public static CardInfo.Colors color;

    public static List<int> deck = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                                                     2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                                                     3, 3, 3, 3, 3, 3, 3, 3 ,3, 3 };

    // 手札（カードIDのリスト）
    public static int[] cards = new int[5];

    // 墓地（カードIDのリスト）
    public static List<int> graveyard = new List<int>();

    // ジョーカーのカードID
    public static int joker;

    // 攻撃にかかる時間
    public static int attackFrame;

    /// <summary>
    /// エネミー情報をセット
    /// </summary>
    /// <param name="id">エネミーID</param>
    public static void SetEnemyInfo(int id)
    {
        enemyId = id;

        switch (id)
        {
            case 1:
                enemyName = "ソードスケルトン";
                maxHp = 30;
                nowHp = maxHp;
                deck = new List<int>() { 88, 88, 88, 88, 88, 89, 89, 89, 89, 89, 90, 90, 90, 90, 90,  // ひっかき: 1ダメージ
                                         10, 10, 10, 11, 11, 11, 12, 12, 12 };                        // 強斬撃: 2ダメージ
                attackFrame = 300;
                break;
            case 2:
                enemyName = "ゾンビ";
                maxHp = 50;
                nowHp = maxHp;
                deck = new List<int>() { 88, 88, 89, 89, 90, 90,                // ひっかき: 1ダメージ
                                         91, 91, 91, 92, 92, 92, 93, 93, 93,    // かみつき: ２ダメージ
                                         10, 11, 12 };                          // 強斬撃: 2ダメージ
                attackFrame = 300;
                break;
            case 3:
                enemyName = "ソードスケルトン";
                maxHp = 30;
                nowHp = maxHp;
                deck = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                attackFrame = 300;
                break;
            case 4:
                enemyName = "アンデッドドラゴン";
                maxHp = 30;
                nowHp = maxHp;
                deck = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                attackFrame = 300;
                break;
            case 5:
                enemyName = "黒龍";
                maxHp = 100;
                nowHp = maxHp;
                deck = new List<int>() { 88, 89, 90,                             // ひっかき: 1ダメージ
                                         91, 91, 92, 92, 93, 93,                 // かみつき: 2ダメージ
                                         94, 94, 94, 95, 95, 95, 96, 96, 96,     // 大薙: 3ダメージ
                                         97, 98, 99 };                           // ドラゴンブレス: 5ダメージ
                attackFrame = 300;
                break;
        }

        Shuffle(deck);
        for (int i = 0; i < 5; i++)
        {
            cards[i] = deck[0];
            deck.RemoveAt(0);
        }
    }

    /// <summary>
    /// プレイヤーの色を進める
    /// </summary>
    public static void NextColor()
    {
        if (color == CardInfo.Colors.blue)
        {
            color = CardInfo.Colors.yellow;
            return;
        }

        if (color == CardInfo.Colors.yellow)
        {
            color = CardInfo.Colors.red;
            return;
        }

        if (color == CardInfo.Colors.red)
        {
            color = CardInfo.Colors.blue;
            return;
        }
    }

    /// <summary>
    /// デッキをシャッフルする
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">デッキのリスト</param>
    public static void Shuffle<T>(IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
