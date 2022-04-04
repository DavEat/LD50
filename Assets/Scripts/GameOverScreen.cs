using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject m_noFood;
    [SerializeField] GameObject m_killedGnome;
    [SerializeField] GameObject m_noWitch;

    [SerializeField] GameObject m_victory;

    public void DisplayGameOver(bool noFood, bool killedG, bool noWitch)
    {
        gameObject.SetActive(true);

        if (noFood)
        {
            m_noFood.SetActive(true);
        }
        else if (killedG)
        {
            m_killedGnome.SetActive(true);
        }
        else if (noWitch)
        {
            m_noWitch.SetActive(true);
        }
        else
        {
            m_victory.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown(GameManager.inst.NextDialogButton))
        {
            GameManager.inst.GoToNextScene();
        }
    }
}
