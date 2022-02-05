using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 効果音のコントローラクラス
/// </summary>
public class SoundEffectCommon : MonoBehaviour
{
    public enum SoundType
    {
        Select,
        Ok,
        Cancel,
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6,
        Player7,
        Player8,
        Player9,
        Player10,
        Enemy1,
        Enemy2,
        Enemy3
    }

    AudioSource audioSource;

    public AudioClip select;        // カーソルセレクト音
    public AudioClip ok;            // 決定音
    public AudioClip cancel;        // キャンセル・エラー音
    public AudioClip player1;       // プレイヤー効果音1
    public AudioClip player2;       // プレイヤー効果音2
    public AudioClip player3;       // プレイヤー効果音3
    public AudioClip player4;       // プレイヤー効果音4
    public AudioClip player5;       // プレイヤー効果音5
    public AudioClip player6;       // プレイヤー効果音6
    public AudioClip player7;       // プレイヤー効果音7
    public AudioClip player8;       // プレイヤー効果音8
    public AudioClip player9;       // プレイヤー効果音9
    public AudioClip player10;      // プレイヤー効果音10
    public AudioClip enemy1;        // エネミー効果音1
    public AudioClip enemy2;        // エネミー効果音2
    public AudioClip enemy3;        // エネミー効果音3

    private bool started = false;
    public SoundType soundType;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();

        switch (soundType)
        {
            case SoundType.Select:
                audioSource.PlayOneShot(select);
                break;

            case SoundType.Ok:
                audioSource.PlayOneShot(ok);
                break;

            case SoundType.Cancel:
                audioSource.PlayOneShot(cancel);
                break;

            case SoundType.Player1:
                audioSource.PlayOneShot(player1);
                break;

            case SoundType.Player2:
                audioSource.PlayOneShot(player2);
                break;

            case SoundType.Player3:
                audioSource.PlayOneShot(player3);
                break;

            case SoundType.Player4:
                audioSource.PlayOneShot(player4);
                break;

            case SoundType.Player5:
                audioSource.PlayOneShot(player5);
                break;

            case SoundType.Player6:
                audioSource.PlayOneShot(player6);
                break;

            case SoundType.Player7:
                audioSource.PlayOneShot(player7);
                break;

            case SoundType.Player8:
                audioSource.PlayOneShot(player8);
                break;

            case SoundType.Player9:
                audioSource.PlayOneShot(player9);
                break;

            case SoundType.Player10:
                audioSource.PlayOneShot(player10);
                break;

            case SoundType.Enemy1:
                audioSource.PlayOneShot(enemy1);
                break;

            case SoundType.Enemy2:
                audioSource.PlayOneShot(enemy2);
                break;

            case SoundType.Enemy3:
                audioSource.PlayOneShot(enemy3);
                break;
        }

        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 再生後オブジェクトを破棄する
        if(started && !audioSource.isPlaying)
        {
            Destroy(transform.gameObject);
        }
    }
}
