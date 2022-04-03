using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] MeleeWeapon m_weapon;

    [SerializeField] AnimationManager m_am;

    [SerializeField] float dm_coolDown_strike = 2;
    [SerializeField] float dm_coolDown_turn = 3;

    float m_coolDown_strike;
    float m_coolDown_turn;

    void Update()
    {
        if (Input.GetButtonDown(GameManager.inst.MeleeAttackButton_Strike) && m_coolDown_strike < Time.time)
        {
            //TODO prevent movement
            m_coolDown_strike = dm_coolDown_strike + Time.time;
            m_am.Strike();
        }
        if (Input.GetButtonDown(GameManager.inst.MeleeAttackButton_Turn) && m_coolDown_turn < Time.time)
        {
            //TODO prevent movement
            m_coolDown_turn = dm_coolDown_turn + Time.time;
            m_am.Turn();
        }
    }
}