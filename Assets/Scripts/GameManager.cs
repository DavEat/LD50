using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Transform player;

    public Transform projectileContainer;


    public string MeleeAttackButton_Strike = "Fire1";
    public string MeleeAttackButton_Turn = "Fire2";
}