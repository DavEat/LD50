using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifePoints : LifePoints
{
    protected override void Die()
    {
        Debug.Log($"{name}: died");
        gameObject.SetActive(false);
    }
}