using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// プレイヤーカラーのコントローラクラス
/// </summary>
public class ColorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.color == CardInfo.Colors.blue)
        {
            transform.Find("Color/Blue").GetComponent<Image>().DOFade(1f, 0.5f);
            transform.Find("Color/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("Color/Red").GetComponent<Image>().DOFade(0f, 0.5f);

            transform.Find("Blue/Image").GetComponent<Image>().DOFade(1f, 0f);
            transform.Find("Yellow/Image").GetComponent<Image>().DOFade(0.4f, 0f);
            transform.Find("Red/Image").GetComponent<Image>().DOFade(0.4f, 0f);
        }
        else if (Player.color == CardInfo.Colors.yellow)
        {
            transform.Find("Color/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("Color/Yellow").GetComponent<Image>().DOFade(1f, 0.5f);
            transform.Find("Color/Red").GetComponent<Image>().DOFade(0f, 0.5f);

            transform.Find("Blue/Image").GetComponent<Image>().DOFade(0.4f, 0f);
            transform.Find("Yellow/Image").GetComponent<Image>().DOFade(1f, 0f);
            transform.Find("Red/Image").GetComponent<Image>().DOFade(0.4f, 0f);
        }
        else
        {
            transform.Find("Color/Blue").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("Color/Yellow").GetComponent<Image>().DOFade(0f, 0.5f);
            transform.Find("Color/Red").GetComponent<Image>().DOFade(1f, 0.5f);

            transform.Find("Blue/Image").GetComponent<Image>().DOFade(0.4f, 0f);
            transform.Find("Yellow/Image").GetComponent<Image>().DOFade(0.4f, 0f);
            transform.Find("Red/Image").GetComponent<Image>().DOFade(1f, 0f);
        }
    }
}
