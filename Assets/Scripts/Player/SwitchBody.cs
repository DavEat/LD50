using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBody : MonoBehaviour
{
    [SerializeField] AnimationManager m_animManager;
    [SerializeField] Animator m_hunter;
    [SerializeField] Animator m_troll;

    [SerializeField] bool debug;

    public void Switch(bool troll)
    {
        if (troll)
        {
            m_troll.gameObject.SetActive(true);
            m_animManager.SetAnimator(m_troll);
            m_hunter.gameObject.SetActive(false);
        }
        else
        {
            m_hunter.gameObject.SetActive(true);
            m_animManager.SetAnimator(m_hunter);
            m_troll.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (debug)
        {
            debug = false;
            Switch(!m_troll.gameObject.activeSelf);
        }
    }
}