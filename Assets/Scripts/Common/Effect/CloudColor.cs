
using UnityEngine;
using UnityEngine.UI;

public class CloudColor : MonoBehaviour
{
    [SerializeField] SpriteRenderer          m_render;
    [SerializeField] AnimationCurve m_animCurve;
    [SerializeField] float          m_animTime     = 1.5f;
    [SerializeField] Color          m_punchValue   = Color.white;
    [SerializeField] bool           m_startOnAwake = false;
    [SerializeField] bool           m_loop         = false;

    float m_timer     = 0f;
    bool  m_isPlaying = false;
    Color m_original  = Color.white;

    void Awake()
    {
        m_isPlaying = m_startOnAwake;
        m_timer     = 0f;
        if (!m_render) { m_render = GetComponent<SpriteRenderer>(); }
        if (m_render)
        {
            m_original = m_render.color;
        }
    }

    public void Play()
    {
        if (!m_render) { m_render = GetComponent<SpriteRenderer>(); }
        if (m_render)
        {
            m_timer     = 0.0f;
            m_isPlaying = true;
        }
    }

    public void Stop()
    {
        m_timer     = 0.0f;
        m_isPlaying = false;
        if (m_render)
        {
            m_render.color = m_original;
        }
    }

    void Update()
    {
        if (m_isPlaying)
        {
            bool endAnim = false;
            if (m_timer < m_animTime)
            {
                m_timer += Time.deltaTime;
            }
            else
            {
                if (m_loop)
                {
                    m_timer -= m_animTime;
                }
                else
                {
                    m_timer = m_animTime;
                    endAnim = true;
                }
            }

            if (m_isPlaying)
            {
                float ratio = m_animTime > 0 ? m_timer / m_animTime : 0f;
                Color diff  = m_punchValue - m_original;

                float colorR = m_original.r + diff.r * m_animCurve.Evaluate(ratio);
                float colorG = m_original.g + diff.g * m_animCurve.Evaluate(ratio);
                float colorB = m_original.b + diff.b * m_animCurve.Evaluate(ratio);
                float colorA = m_original.a + diff.a * m_animCurve.Evaluate(ratio);

                Color color = m_render.color;
                color.r        = colorR;
                color.g        = colorG;
                color.b        = colorB;
                color.a        = colorA;
                m_render.color = color;
            }

            if (endAnim)
            {
                m_isPlaying    = false;
                m_render.color = m_original;
            }
        }
    }
}