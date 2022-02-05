using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGMのコントローラクラス
/// </summary>
public class BgmController : MonoBehaviour
{
    private static int bgmId = 1;

    public AudioClip title;
    public AudioClip normalBattle;
    public AudioClip bossBattle;
    public AudioClip battleWin;
    public AudioClip battleLose;

    public static AudioClip bgm1;
    public static AudioClip bgm2;
    public static AudioClip bgm3;
    public static AudioClip bgm4;
    public static AudioClip bgm5;
    public static Transform audioTransform;

    private void Awake()
    {
        bgmId = 1;
        InitBgmInfo();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// BGMのオーディオクリップを初期化
    /// </summary>
    private void InitBgmInfo()
    {
        bgm1 = title;
        bgm2 = normalBattle;
        bgm3 = bossBattle;
        bgm4 = battleWin;
        bgm5 = battleLose;
        audioTransform = transform;
    }

    /// <summary>
    /// BGMを引数IDのBGMに切り替える
    /// </summary>
    /// <param name="bgmId">BGMのID</param>
    public static void ChangeBgm(int id)
    {
        if(audioTransform == null) { return; }

        audioTransform.GetComponent<AudioSource>().Pause();

        switch (id)
        {
            case 1:
                audioTransform.GetComponent<AudioSource>().clip = bgm1;
                break;
            case 2:
                audioTransform.GetComponent<AudioSource>().clip = bgm2;
                break;
            case 3:
                audioTransform.GetComponent<AudioSource>().clip = bgm3;
                break;
            case 4:
                audioTransform.GetComponent<AudioSource>().clip = bgm4;
                break;
            case 5:
                audioTransform.GetComponent<AudioSource>().clip = bgm5;
                break;
        }

        audioTransform.GetComponent<AudioSource>().Play();
    }
}
