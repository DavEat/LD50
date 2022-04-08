using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    [SerializeField] float m_speed = 1;
    //[SerializeField] float m_accelerationMul = 1;
    //[SerializeField] float m_maxVelocity = 30;

    float inputX, inputZ;

    Transform m_transform;
    Rigidbody m_rigidbody;
    
    void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_rigidbody = GetComponent<Rigidbody>();

        GameManager.inst.player = m_transform;
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (DialogsManager.inst.InDialog || !m_status.mCanMove)
            return;

        if (Mathf.Abs(inputX) > .1f || Mathf.Abs(inputZ) > .1f)
        {
            Vector3 direction = Quaternion.Euler(0, 45, 0) * new Vector3(inputX, 0, inputZ).normalized;
            m_rigidbody.velocity = direction * m_speed;

            m_transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else 
        {
            if (m_rigidbody.velocity.sqrMagnitude > .01f)
                m_rigidbody.velocity *= .9f;
            else m_rigidbody.velocity = Vector3.zero;
        }
    }
}