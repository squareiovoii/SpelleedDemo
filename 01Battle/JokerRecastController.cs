using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ジョーカーのリキャスト回数コントローラクラス
/// </summary>
public class JokerRecastController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // リキャスト回数のテキストを更新する
        if (CardJokerController.nowRecast <= 0)
        {
            transform.GetComponent<Text>().text = "発動OK";
        }
        else
        {
            transform.GetComponent<Text>().text = "あと" + CardJokerController.nowRecast.ToString() + "枚";
        }
    }
}
