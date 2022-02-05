using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームのDirectorクラス
/// </summary>
public static class GameDirector
{
    public static bool isStartGame = false; // ゲームの開始フラグ

    /// <summary>
    /// 効果音を呼び出す
    /// </summary>
    /// <param name="tran">トランスフォーム</param>
    /// <param name="type">効果音のタイプ</param>
    public static void DoSound(Transform tran, SoundEffectCommon.SoundType type)
    {

        GameObject prefab = (GameObject)Resources.Load("Sound/SoundEffects");
        GameObject obj = MonoBehaviour.Instantiate(prefab, Vector2.zero, Quaternion.identity, tran);

        //MonoBehaviour.DontDestroyOnLoad(obj);

        //効果音の種類を設定
        SoundEffectCommon script = obj.GetComponent<SoundEffectCommon>();
        script.soundType = type;
    }

}
