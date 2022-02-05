using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// モンスター画像のコントローラクラス
/// </summary>
public class EncountEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().DOFade(1f, 2f).OnComplete(() => { EnemyController.isEncount = true; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
