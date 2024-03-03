using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public event Action OutOfBoundsCollision;

    //Detecte une collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { OutOfBoundsCollision?.Invoke(); }
    }
}
