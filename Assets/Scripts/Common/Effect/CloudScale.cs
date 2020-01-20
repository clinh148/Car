using UnityEngine;

public class CloudScale : MonoBehaviour
{
    [SerializeField] AnimationCurve m_animCurve;
    [SerializeField] float          m_animTime     = 1.5f;
    [SerializeField] Vector3        m_punchValue   = Vector3.one;
    [SerializeField] bool           m_startOnAwake = false;
    [SerializeField] bool           m_loop         = false;

    float   m_timer     = 0f;
    bool    m_isPlaying = false;
    Vector3 m_scale     = Vector3.one;

    void Awake()
    {
        m_isPlaying = m_startOnAwake;
        m_timer     = 0f;
        m_scale = transform.localScale;
    }

    public void Play()
    {
        m_timer     = 0.0f;
        m_isPlaying = true;
        m_scale     = transform.localScale;
    }

    public void Stop()
    {
        m_timer              = 0.0f;
        m_isPlaying          = false;
        transform.localScale = m_scale;
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

                float scaleX = m_scale.x + m_punchValue.x * m_animCurve.Evaluate(ratio);
                float scaleY = m_scale.y + m_punchValue.y * m_animCurve.Evaluate(ratio);
                float scaleZ = m_scale.z + m_punchValue.z * m_animCurve.Evaluate(ratio);

                Vector3 scale = transform.localScale;
                scale.x              = scaleX;
                scale.y              = scaleY;
                scale.z              = scaleZ;
                transform.localScale = scale;
            }

            if (endAnim)
            {
                m_isPlaying = false;
            }
        }
    }
}