using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : Enemy
{
    [SerializeField] Transform m_spearSpawnPoint;
    [SerializeField] Spear m_spearPrefab;

    [SerializeField] float m_coolDownTimeReload = .5f;
    [SerializeField] float m_coolDownTimeAfterReload = .5f;

    Spear m_spear;
    float m_coolDown;

    private void Start()
    {
        if (m_states.leftHanded)
        {
            m_spearSpawnPoint.localPosition = new Vector3(-m_spearSpawnPoint.localPosition.x, m_spearSpawnPoint.localPosition.y, m_spearSpawnPoint.localPosition.z);
        }
    }

    void FixedUpdate()
    {
        if (!m_states.c_canShot)
            return;

        if (m_states.moving)
            return;



        if (m_coolDown < Time.time)
        {
            if (m_spear == null)
                SpawnSpear();

            m_states.canShot = RotateToAttack();

            if (!m_states.canShot)
                return;

            else ShootSpear();
        }
    }

    void SpawnSpear()
    {
        m_coolDown = Time.time + m_coolDownTimeAfterReload;

        m_spear = Instantiate(m_spearPrefab, m_spearSpawnPoint.position, m_spearSpawnPoint.rotation, m_spearSpawnPoint);
        m_spear.enabled = false;
    }
    void ShootSpear()
    {
        m_coolDown = Time.time + m_coolDownTimeReload;
                 
        m_spear.Init((m_spearSpawnPoint.position - GameManager.inst.player.position).magnitude, GameManager.inst.projectileContainer);
        m_spear = null;
    }
}