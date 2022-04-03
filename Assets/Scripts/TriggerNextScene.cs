using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.inst.PlayerTag))
        {
            GameManager.inst.Check_GoToNextScene();
        }
    }
}