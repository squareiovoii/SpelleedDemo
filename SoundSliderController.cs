using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// サウンドスライダーのコントローラクラス
/// </summary>
[RequireComponent(typeof(Slider))]
public class SoundSliderController : MonoBehaviour
{
    Slider slider; //スライダー

    void Awake()
    {
        // ゲーム開始時には音量を0にする
        if (!GameDirector.isStartGame)
        {
            AudioListener.volume = 0;
            GameDirector.isStartGame = true;
        }
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume;
    }

    private void OnEnable()
    {
        //スライダーの値で音量を調整する
        slider.value = AudioListener.volume;
        slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }
}