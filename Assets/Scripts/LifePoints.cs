using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifePoints : MonoBehaviour
{
    [SerializeField] Material m_hurtMat;
    [SerializeField] float m_hurtMatDuration = .3f;
    float m_time;
    bool m_hurtMatActive;

    [SerializeField] int m_lifePoints;
    [SerializeField] int m_maxLifePoints = 10;

    [SerializeField] protected UnityEvent m_dieEvent;

    void Start()
    {
        m_lifePoints = m_maxLifePoints;

        // create instance of material
        m_hurtMat = new Material(m_hurtMat);
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(true); 
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
            SetHurtShader(false);

            m_hurtMatActive = false;
            //m_hurtMat.SetInt("_Active", 0);
        }
    }

    public void GetDamage(int damage)
    {
        if (m_lifePoints <= 0)
            return;

        m_lifePoints -= damage;
        {
            SetHurtShader(true);

            //m_hurtMat.SetInt("_Active", 1);
            m_time = m_hurtMatDuration + Time.time;
            m_hurtMatActive = true;
        }

        if (m_lifePoints <= 0)
        {
            Die();
        }
    }

    void SetHurtShader(bool hurt)
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            if (renderers[i].materials.Length > 1)
                renderers[i].materials[1].SetInt("_Active", hurt ? 1 : 0);
        }
    }

    protected virtual void Die()
    {
        m_dieEvent?.Invoke();

        Debug.Log($"{name}: died");
        GetComponent<AnimationManager>()?.Die();


        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}