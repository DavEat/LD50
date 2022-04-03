using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAngle : MonoBehaviour
{
    void Start()
    {
        int r = Random.Range(0, 4);
        if (r > 0)
            transform.rotation = Quaternion.Euler(0, 90 * r, 0);
    }
}