using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundIconController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AudioListener.volume == 0)
        {
            transform.Find("ON").DOScale(0f, 0f);
            transform.Find("OFF").DOScale(1f, 0f);
        }
        else
        {
            transform.Find("ON").DOScale(1f, 0f);
            transform.Find("OFF").DOScale(0f, 0f);
        }
    }
}
