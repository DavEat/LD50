using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBody : MonoBehaviour
{


    [SerializeField] AnimationManager m_animManager;
    [SerializeField] Animator m_hunter;
    [SerializeField] Animator m_troll;

    [SerializeField] bool debug;

    [SerializeField] AudioSource m_source;
    [SerializeField] AudioClip[] m_clips;

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

        SoundManager.PlaySound(m_source, m_clips, true);
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