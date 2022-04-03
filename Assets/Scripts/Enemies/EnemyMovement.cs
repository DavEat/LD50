using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : Enemy
{
    [Range(-1, 50)]
    [SerializeField] float m_minRange = 1;
    [Range(-1, 50)]
    [SerializeField] float m_maxRange = 1;

    [Range(-1, 50)]
    [SerializeField] float m_detectionRange = 10;

    Vector3 m_lastTargetPos;

    NavMeshAgent m_agent;


    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();

        m_transform.rotation = Quaternion.LookRotation(GameManager.inst.player.position - m_transform.position, Vector3.up);
    }

    void FixedUpdate()
    {
        if (m_states.death)
            return;

        if (DialogsManager.inst.InDialog)
        {
            m_agent.isStopped = true;
            return;
        }
        else m_agent.isStopped = false;

        if (!m_states.canMove)
            return;

        Vector3 playerPos = GameManager.inst.player.position;
        Vector3 direction = m_transform.position - playerPos;

        float sqr = direction.sqrMagnitude;

        if (!m_states.mTargetDetected)
        {
            if (sqr < m_detectionRange * m_detectionRange)
            {
                m_states.mTargetDetected = true;
            }
            else return;
        }

        Vector3 targetPos;
        if (sqr > m_maxRange * m_maxRange)
        {
            targetPos = playerPos + direction.normalized * m_maxRange;
        }
        else if (sqr < m_minRange * m_minRange)
        {
            targetPos = playerPos + direction.normalized * m_minRange;
        }
        else
        {
            targetPos = m_transform.position;
        }

        m_states.moving = m_agent.velocity.sqrMagnitude > 0.1f;

        if (targetPos != m_lastTargetPos)
        {
            m_lastTargetPos = targetPos;

            if (!m_agent.SetDestination(targetPos))
                m_agent.SetDestination(m_transform.position);
        }
    }

    public override void Died()
    {
        base.Died();

        if (m_agent != null)
            m_agent.enabled = false;
    }
}