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

    int m_nextSceneIndex;
    [SerializeField] int numverOfScene = 2;

    [SerializeField] GameOverScreen m_gameOver;

    public void GoToFirstScene()
    {
        SceneManager.LoadScene(m_nextSceneIndex);
    }

    public void Check_GoToNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index >= numverOfScene)
            index = 0;

        if (!boarKilled)
        {
            Debug.Log("You didn't found food for you and your wife, already weak you got sike and died");
            index = 0;
        }
        else if (!witchKilled)
        {
            Debug.Log("You did not found a cure for your affliction, while returning home in the first light of the day you changed into stone");
            index = 0;
        }

        m_nextSceneIndex = index;

        m_gameOver.DisplayGameOver(!boarKilled, killedByGnome, !witchKilled);
    }
}