using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int m_damage = 1;
}

public abstract class MeleeWeapon : Weapon
{
    public abstract float Use();
}