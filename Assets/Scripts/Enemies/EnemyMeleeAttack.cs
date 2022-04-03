using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : Enemy
{
    [SerializeField] MeleeWeapon m_weaponprefab;

    [SerializeField] MeleeWeapon m_weapon;
    [SerializeField] Transform m_meleeWeaponPosition;

    float m_coolDown;

    void Start()
    {
        if (m_states.canMelee && m_weaponprefab != null)
        {
            if (m_states.leftHanded)
            {
                m_meleeWeaponPosition.localPosition = new Vector3(-m_meleeWeaponPosition.localPosition.x, m_meleeWeaponPosition.localPosition.y, m_meleeWeaponPosition.localPosition.z);
            }
            m_weapon = Instantiate(m_weaponprefab, m_meleeWeaponPosition.position, m_meleeWeaponPosition.rotation, m_meleeWeaponPosition);
        }
    }

    void FixedUpdate()
    {
        if (!m_states.canMelee)
            return;

        if (m_states.moving)
            return;

        if (!RotateToAttack())
            return;

        if (m_coolDown < Time.time)
        {
            m_coolDown = m_weapon.Use() + Time.time;
        }
    }
}