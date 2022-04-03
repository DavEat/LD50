using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Halbard : MeleeWeapon
{
    [SerializeField] bool m_stun;
    [SerializeField] bool m_push;
    [SerializeField] float m_pushForce = 10;

    public override float Use()
    {
        throw new System.NotImplementedException();
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

                if (m_push)
                {
                    lps.GetComponent<Rigidbody>().AddForce(transform.parent.forward * m_pushForce, ForceMode.Force);
                }
                if (m_stun)
                {
                    //TODO
                }
            }
        }
    }
}