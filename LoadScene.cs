using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移クラス
/// </summary>
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// シーン遷移する
    /// </summary>
    /// <param name="name">シーン名</param>
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// トランジションを表示して画面遷移する
    /// </summary>
    /// <param name="name">シーン名</param>
    public void ChangeSheneTransiton(string name)
    {
        transform.Find("Transition").DOScale(1f, 0f);
        transform.Find("Transition/Image").GetComponent<Image>().DOFade(1f, 2f).OnComplete(()=> { ChangeScene(name); });
    }

    /// <summary>
    /// タイトルに戻る
    /// （BGMのゲームオブジェクトを削除する）
    /// </summary>
    public void ReturnTitle(string name)
    {
        Destroy(GameObject.Find("BGM"));
        SceneManager.LoadScene(name);
    }
}
