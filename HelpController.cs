using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// ヘルプボタンのコントローラクラス
/// </summary>
public class HelpController : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHelp()
    {
        transform.Find("Contents").DOScale(1f, time);
    }

    public void CloseHelp()
    {
        transform.Find("Contents").DOScale(0f, time);
    }
}
