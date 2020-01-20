
using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    [SerializeField] float          m_animTime = 1.5f;
    [SerializeField] Vector3        m_start;
    [SerializeField] Vector3        m_stop;
    [SerializeField] AnimationCurve m_moveCurve;
    [SerializeField] bool           m_startOnAwake = false;
    [SerializeField] bool           m_loop         = false;

    float         m_timer     = 0f;
    bool          m_isPlaying = false;

    public Vector3 Start { get { return m_start; } set { m_start = value; } }
    public Vector3 Stop { get { return m_stop; } set { m_stop = value; } }
    public bool IsPlaying { get { return m_isPlaying; } set { m_isPlaying = value; } }

    void Awake()
    {
        m_timer = 0.0f;
        m_isPlaying = m_startOnAwake;
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
                float ratio     = m_animTime > 0 ? m_timer / m_animTime : 0f;
                float distanceX = m_stop.x - m_start.x;
                float distanceY = m_stop.y - m_start.y;

                float posX = m_start.x + distanceX * m_moveCurve.Evaluate(ratio);
                float posY = m_start.y + distanceY * m_moveCurve.Evaluate(ratio);

                Vector3 pos = transform.localPosition;
                pos.x = posX;
                pos.y = posY;
                transform.localPosition = pos;
            }

            if (endAnim)
            {
                m_isPlaying = false;
            }
        }
    }
}