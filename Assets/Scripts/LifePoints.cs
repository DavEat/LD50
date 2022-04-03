using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    [SerializeField] Material m_hurtMat;
    [SerializeField] float m_hurtMatDuration = .3f;
    float m_time;
    bool m_hurtMatActive;

    [SerializeField] int m_lifePoints;
    [SerializeField] int m_maxLifePoints = 10;


    void Start()
    {
        m_lifePoints = m_maxLifePoints;

        // create instance of material
        m_hurtMat = new Material(m_hurtMat);
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(); 
        for (int i = 0; i < renderers.Length; i++)
        {
            if (renderers[i].materials.Length > 1)
                renderers[i].materials[1] = m_hurtMat;
        }
    }

    void Update()
    {
        if (m_hurtMatActive && m_time < Time.time)
        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].materials.Length > 1)
                    renderers[i].materials[1].SetInt("_Active", 0);
            }

            m_hurtMatActive = false;
            //m_hurtMat.SetInt("_Active", 0);
        }
    }

    public void GetDamage(int damage)
    {
        m_lifePoints -= damage;

        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].materials.Length > 1)
                    renderers[i].materials[1].SetInt("_Active", 1);
            }

            //m_hurtMat.SetInt("_Active", 1);
            m_time = m_hurtMatDuration + Time.time;
            m_hurtMatActive = true;
        }

        if (m_lifePoints <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Debug.Log($"{name}: died");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}