using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] int m_sceneIndex = 1;
    void Start()
    {
        SceneManager.LoadScene(m_sceneIndex);
    }
}