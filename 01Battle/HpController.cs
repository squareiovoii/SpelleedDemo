using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーHPのコントローラクラス
/// </summary>
public class HpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Bar").GetComponent<Image>().fillAmount = (float)Player.nowHp / (float)Player.maxHp;
        transform.Find("Image/Text").GetComponent<Text>().text = ShowHp();
    }

    private string ShowHp()
    {
        if(Player.nowHp > 0)
        {
            return Player.nowHp.ToString();
        }
        else
        {
            return "0";
        }
    }
}
