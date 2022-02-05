using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2Dボーンアニメーションのコントローラクラス
/// </summary>
/// <remarks>
/// 引用元:
///  [Unity] 2D Animation でやる気のない Just Do It 動画を作る｜Qiita
///  https://qiita.com/ELIXIR/items/150374b29e249d8dca27
/// </remarks>
public class PendulumTransform : MonoBehaviour
{
    [SerializeField] Transform m_targetTr = null;
    [SerializeField, Range(-180f, 180f)] float m_range = 5f;
    [SerializeField, Range(0.5f, 100f)] float m_period = 4f;
    Quaternion m_defRot;
    float m_freqTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (m_targetTr == null)
        {
            m_targetTr = transform;
        }
        m_defRot = m_targetTr.localRotation;
        m_freqTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_freqTimer += Time.deltaTime / m_period;
        if (m_freqTimer > 1f)
        {
            m_freqTimer -= 1f;
        }
        float amgle = Mathf.Sin(m_freqTimer * Mathf.PI * 2f);
        m_targetTr.localRotation = m_defRot * Quaternion.AngleAxis(amgle * m_range, Vector3.forward);
    }
}
