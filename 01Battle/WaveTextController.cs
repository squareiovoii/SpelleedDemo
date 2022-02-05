using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WAVEテキストのコントローラクラス
/// </summary>
public class WaveTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyController.wave <= 3)
        {
            transform.GetComponent<Text>().text = "WAVE " + EnemyController.wave.ToString();
        }
    }
}
