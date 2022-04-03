using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
    [SerializeField] float m_coolDown = 1f;

    Animator m_animator;
    static int m_useHash;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        if (m_useHash == 0)
            m_useHash = Animator.StringToHash("_Use");
    }

    public override float Use()
    {
        m_animator.SetTrigger(m_useHash);
        return m_coolDown;
    }

    void OnTriggerEnter(Collider other)
    {
        if (DialogsManager.inst.InDialog)
            return;

        //if (other.CompareTag("Player"))
        {
            LifePoints lps = other.GetComponent<LifePoints>();
            if (lps != null)
            {
                lps.GetDamage(m_damage);
            }
        }
    }
}