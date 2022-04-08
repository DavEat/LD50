using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Transform player;

    public Transform projectileContainer;

    public bool boarKilled = true;
    public void SetBoarKilled() { boarKilled = true; }
    public bool killedByGnome;
    public void SetKilledByGnome() { killedByGnome = true; }
    public bool witchKilled;
    public void SetWitchKilled() { witchKilled = true; }

    //[SerializeField] int noFoodSceneIndex; 
    //[SerializeField] int noWitchKillSceneIndex;

    public string PlayerTag = "Player";

    public string MeleeAttackButton_Strike = "Fire1";
    public string MeleeAttackButton_Turn = "Fire2";

    public string NextDialogButton = "Fire1";

    [SerializeField] int m_nextSceneIndex;
    [SerializeField] int m_startSceneIndex = 1;
    [SerializeField] int m_numverOfScene = 4; //minus init

    [SerializeField] GameOverScreen m_gameOver;

    [SerializeField] bool m_stopMusicOnStart = false;
    void Start()
    {
        if (m_stopMusicOnStart)
        {
            SoundManager.inst?.StopMusic();
        }
        else
        {
            SoundManager.inst?.StartMusic();
        }
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(m_nextSceneIndex);
    }
    
    public void Check_GoToNextScene()
    {
        DialogsManager.inst.m_inDialog = true;

        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index >= m_numverOfScene + m_startSceneIndex)
            index = m_startSceneIndex;

        if (killedByGnome)
        {
            Debug.Log("Killed by gnomes");
            index = SceneManager.GetActiveScene().buildIndex;
        }
        if (!boarKilled)
        {
            Debug.Log("You didn't found food for you and your wife, already weak you got sike and died");
            index = SceneManager.GetActiveScene().buildIndex;
        }
        else if (!witchKilled)
        {
            Debug.Log("You did not found a cure for your affliction, while returning home in the first light of the day you changed into stone");
            index = SceneManager.GetActiveScene().buildIndex;
        }

        m_nextSceneIndex = index;

        m_gameOver.DisplayGameOver(!boarKilled, killedByGnome, !witchKilled);
    }
}