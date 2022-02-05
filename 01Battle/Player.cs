using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
public static class Player
{
    public static int playerId;
    public static string playerName;

    // ヒットポイント
    public static int maxHp = 30;
    public static int nowHp = 30;

    // 現在の色
    public static CardInfo.Colors color;

    // デッキ（カードIDのリスト）
    public static List<int> deck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                                     11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                                     21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

    // 手札（カードIDのリスト）
    public static int[] cards = new int[5];

    // 墓地（カードIDのリスト）
    public static List<int> graveyard = new List<int>();

    // ジョーカーのカードID
    public static int joker = 101;

    // カードの使用回数をカウントし、カードの使用回数を返す
    // TODO: 要素数はカードの種類に合わせる
    public static int[] usedCard = new int[200];
    public static void AddUseCount(int cardId) { usedCard[cardId - 1] += 1; }
    public static int GetUseCount(int cardId) { return usedCard[cardId - 1]; }

    /// <summary>
    /// プレイヤーのステータスを読み込む
    /// TODO: 要調整
    /// </summary>
    /// <param name="id">プレイヤーID</param>
    public static void InitPlayerInfo()
    {
        // TODO: IDの設定など
        playerId = 0;
        playerName = "";

        maxHp = 30;
        nowHp = maxHp;
        deck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        cards = new int[5];
        graveyard = new List<int>();
    }

    /// <summary>
    /// プレイヤーの色を進める
    /// </summary>
    public static void NextColor()
    {
        if(color == CardInfo.Colors.blue)
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
