using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    [Header("Const states")]
    public bool c_canMove = true;
    public bool c_canMelee = true;
    public bool c_canShot = true;

    public bool leftHanded = false;

    public bool death;

    public void SetDeath(bool value)
    {
        death = value;
    }

    [Space(10)]
    [Header("Proccesing states")]

    public bool moving = false;
    public bool canMove
    {
        get => c_canMove && m_canMove;
        set => m_canMove = value;
    }
    [SerializeField] bool m_canMove = true;
    
    public bool canMelee
    {
        get => c_canMelee && m_canMelee;
        set => m_canMelee = value;
    }
    [SerializeField] bool m_canMelee = false;


    public bool canShot
    {
        get => c_canShot && m_canShot;
        set => m_canShot = value;
    }
    [SerializeField] bool m_canShot = false;


    public bool mAtRange = false;
    public bool mTargetDetected = false;

    [Space(10)]
    [Header("Models states")]

    [SerializeField] MeshFilter m_filter;
    [SerializeField] Mesh m_idle;
    [SerializeField] Mesh m_sword;
    [SerializeField] Mesh m_throw;

    void Awake()
    {
        canMove = c_canMove;
        canMelee = c_canMelee;
        canShot = c_canShot;

        if (m_filter != null)
        {
            leftHanded = Random.Range(0, 1f) < .2f;
            if (leftHanded)
            {
                m_filter.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            if (c_canMelee)
            {
                m_filter.mesh = m_sword;
            }
            else if (c_canShot)
            {
                m_filter.mesh = m_throw;
            }
            else
            {
                m_filter.mesh = m_idle;
            }
        }        
    }
}