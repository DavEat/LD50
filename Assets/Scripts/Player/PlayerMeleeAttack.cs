using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : Player
{
    [SerializeField] MeleeWeapon m_weapon;

    [SerializeField] AnimationManager m_am;
    [SerializeField] Rigidbody m_rb;

    //[SerializeField] float dm_coolDown_strike = 2;
    //[SerializeField] float dm_coolDown_turn = 3;

    //float m_coolDown_strike;
    //float m_coolDown_turn;
    [SerializeField] float m_strikeForceMul = 10;

    [SerializeField] bool m_canStrike = true;
    [SerializeField] bool m_canTurn = true;

    protected override void Start()
    {
        base.Start();

        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (DialogsManager.inst.InDialog)
            return;

        if (Input.GetButtonDown(GameManager.inst.MeleeAttackButton_Strike) && m_status.mCanAttack /*&& m_coolDown_strike < Time.time*/)
        {
            //TODO prevent movement
            //-m_coolDown_strike = dm_coolDown_strike + Time.time;
            m_rb.velocity = Vector3.zero;
            m_rb.AddForce(m_rb.transform.forward * m_strikeForceMul, ForceMode.Impulse);
            m_status.mCanMove = false;

            m_canStrike = false;
            m_status.mCanAttack = false;

            m_am.Strike();
        }
        if (Input.GetButtonDown(GameManager.inst.MeleeAttackButton_Turn) && m_status.mCanAttack /*&& m_coolDown_turn < Time.time*/)
        {
            //TODO prevent movement
            //-m_coolDown_turn = dm_coolDown_turn + Time.time;
            m_rb.velocity = Vector3.zero;
            m_status.mCanMove = false;

            m_canTurn = false;
            m_status.mCanAttack = false;

            m_am.Turn();
        }
    }

    public void SetCanStrike(bool value)
    {
        m_status.mCanMove = true;

        m_canStrike = value;
        m_status.mCanAttack = true;
    }
    public void SetCanTurn(bool value)
    {
        m_status.mCanMove = true;

        m_canTurn = value;
        m_status.mCanAttack = true;
    }
}