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

    [Space(10)]
    [Header("Proccesing states")]

    public bool moving = false;
    public bool canMove
    {
        get => c_canMove && _canMove;
        set => _canMove = value;
    }
    [SerializeField] bool _canMove = true;
    
    public bool canMelee
    {
        get => c_canMelee && _canMelee;
        set => _canMelee = value;
    }
    [SerializeField] bool _canMelee = false;


    public bool canShot
    {
        get => c_canShot && _canShot;
        set => _canShot = value;
    }
    [SerializeField] bool _canShot = false;

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

        leftHanded = Random.Range(0, 1f) < .2f;
        if (leftHanded)
        {
            m_filter.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (c_canMelee)
        {
            m_filter.mesh = m_idle;
        }
        else if (c_canShot)
        {
            m_filter.mesh = m_sword;
        }
        else
        {
            m_filter.mesh = m_throw;
        }
    }
}