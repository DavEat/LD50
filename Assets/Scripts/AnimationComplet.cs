using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComplet : MonoBehaviour
{
    [SerializeField] AnimationManager m_manager;

    void Start()
    {
        m_manager = GetComponentInParent<AnimationManager>();
    }

    public void AnimationCompleted(string name)
    {
        m_manager.AnimationCompleted(name);
    }
}