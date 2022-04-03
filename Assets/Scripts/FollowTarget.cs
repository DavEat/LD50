using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] float m_speed = 1;
    [SerializeField] Transform m_target;

    [SerializeField] bool m_offsetStartPosition;
    [SerializeField] Vector3 m_offset;

    [SerializeField] float m_startFollowAtDst = 0;
    
    bool m_following;
    
    Transform m_transform;

    void Start()
    {
        m_transform = GetComponent<Transform>();

        if (m_offsetStartPosition && m_target != null)
            m_offset = m_transform.position - m_target.position;
    }

    void FixedUpdate()
    {
        if (DialogsManager.inst.InDialog)
            return;

        if (m_target != null)
        {
            float sqrMag = (m_transform.position - (m_target.position + m_offset)).sqrMagnitude;

            if (sqrMag > m_startFollowAtDst * m_startFollowAtDst)
                m_following = true;

            if (m_following)
            {
                if (sqrMag < .1f)
                    m_following = false;
                else
                    m_transform.position = Vector3.LerpUnclamped(m_transform.position, m_target.position + m_offset, Time.deltaTime * m_speed);
            }
        }
    }
}