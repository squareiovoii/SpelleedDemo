using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームオブジェクトを削除する
/// </summary>
public class DestroyTransform : MonoBehaviour
{
    // 何秒後にオブジェクトを破棄するか
    public int waitSecond;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyGameObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // コルーチン本体
    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(waitSecond);
        Destroy(gameObject);
    }
}
