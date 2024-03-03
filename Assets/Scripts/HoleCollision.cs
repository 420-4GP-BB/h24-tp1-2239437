using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCollision : MonoBehaviour
{
    public event Action HoleTriggerEnter;

    //Detecte une collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { HoleTriggerEnter?.Invoke(); }
    }
}
