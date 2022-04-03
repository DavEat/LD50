using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected EnemyStates m_states;
    protected Transform m_transform;

    [SerializeField] float m_attackAngle = 5;

    [SerializeField] float m_rotationSpeed = 5;

    protected virtual void Awake()
    {
        m_states = GetComponent<EnemyStates>();
        m_transform = GetComponent<Transform>();
    }

    protected bool RotateToAttack()
    {
        Vector3 relative = transform.InverseTransformPoint(GameManager.inst.player.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;

        m_transform.Rotate(0, angle * Time.fixedDeltaTime * m_rotationSpeed, 0);

        return Mathf.Abs(angle) < m_attackAngle;
    }
}