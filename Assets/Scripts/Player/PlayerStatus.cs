using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool mCanMove;
    public bool mCanAttack;

    public void ResetValue()
    {
        mCanMove = true;
        mCanAttack = true;
    }
}