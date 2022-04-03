using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] float m_maxVelocityMag = 4.5f;
    [SerializeField] bool m_getRb = false;

    Rigidbody m_rigidbody;
    NavMeshAgent m_agent;
    Animator m_animator;

    static int m_speedHash;
    static int m_strikeHash;
    static int m_turnHash;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponentInChildren<Animator>();

        if (m_speedHash == 0)
            m_speedHash = Animator.StringToHash("_Speed");
        if (m_strikeHash == 0)
            m_strikeHash = Animator.StringToHash("_Strike");
        if (m_turnHash == 0)
            m_turnHash = Animator.StringToHash("_Turn");
    }

    void FixedUpdate()
    {
        float mag = 0;
        if (m_getRb && m_rigidbody != null)
            mag = m_rigidbody.velocity.magnitude;
        else if (m_agent != null)
            mag = m_agent.velocity.magnitude;

        m_animator.SetFloat(m_speedHash, mag / m_maxVelocityMag);
        //Debug.Log($"{name}: {m_agent.velocity.magnitude}"); // default max vel = 4.5 for player
    }

    public void Strike()
    {
        m_animator.SetTrigger(m_strikeHash);
    }
    public void Turn()
    {
        m_animator.SetTrigger(m_turnHash);
    }
}