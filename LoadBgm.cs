using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンのデフォルトBGMを読み込む
/// </summary>
public class LoadBgm : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        BgmController.ChangeBgm(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
