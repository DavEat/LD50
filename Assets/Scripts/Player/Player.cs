using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected PlayerStatus m_status;

    protected virtual void Start()
    {
        m_status = GetComponent<PlayerStatus>();
    }
}