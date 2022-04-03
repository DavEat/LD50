using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    [SerializeField] float angle = .25f;

    [SerializeField] float m_dstOffset = 1.5f;
    [SerializeField] float m_speed = .3f;

    [SerializeField] float m_traveledDst;
    [SerializeField] float m_startYVel;

    [SerializeField] LayerMask m_layer = 1;

    bool m_hittedTheGround;
    float m_time;
    float m_hittedTheGroundDelay = 3f; //bedore sinking into the ground
    bool m_sinking;
    float m_sinkingSpeedMul = .1f;

    Transform m_transform = null;
    Vector3 m_velocity;

    public void Init(float distance, Transform parent)
    {
        enabled = true;

        m_transform = GetComponent<Transform>();
        m_transform.parent = parent;

        float dst = distance + m_dstOffset;
        m_velocity = Quaternion.Euler(0, m_transform.eulerAngles.y, 0) * new Vector3(0, dst * angle - m_transform.position.y, dst);

        m_startYVel = m_velocity.y;
    }

    void FixedUpdate()
    {
        if (DialogsManager.inst.InDialog)
            return;

        if (!m_hittedTheGround)
            Fly();
        else
        {
            if (!m_sinking)
            {
                if (m_time < Time.time)
                {
                    Destroy(gameObject, 2);
                    m_speed *= m_sinkingSpeedMul;
                    m_sinking = true;
                }
            }
            else
            {
                Fly();
            }
        }
    }

    void Fly()
    {
        float percent = m_traveledDst / m_velocity.z;
        m_velocity.y = m_startYVel * (-percent + .5f);

        Vector3 vel = m_velocity * Time.fixedDeltaTime * m_speed;

        m_transform.position += vel;
        m_traveledDst += vel.z;

        Vector3 angle = Quaternion.LookRotation(m_velocity, Vector3.right).eulerAngles;
        angle.z = 0;
        m_transform.eulerAngles = angle;

        if (!m_hittedTheGround)
        {
            if (m_transform.position.y <= 0)
            {
                //enabled = false;
                //Destroy(gameObject, 2);
                m_hittedTheGround = true;
                m_time = m_hittedTheGroundDelay + Time.time;
            }
            else
            {
                if (Physics.Raycast(m_transform.position, Vector3.forward, out RaycastHit hit, 1, m_layer))
                {
                    //if (hit.collider.CompareTag("Player"))
                    LifePoints lps = hit.collider.GetComponent<LifePoints>();
                    if (lps != null)
                    {
                        lps.GetDamage(m_damage);

                        //enabled = false;
                        //m_transform.parent = hit.collider.transform;
                        //Destroy(gameObject, 4);
                    }
                }
            }
        }
    }
}