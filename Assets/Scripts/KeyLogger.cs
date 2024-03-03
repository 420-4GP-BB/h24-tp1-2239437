using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogger : MonoBehaviour
{
    public event Action APress;
    public event Action WPress;
    public event Action SPress;
    public event Action DPress;
    public event Action SpcPress;
    public event Action SpcRelease;
    public event Action OneTap;
    public event Action TwoTap;
    public event Action ThreeTap;
    public event Action NineTap;
    public event Action ZeroTap;
    public event Action LeftClick;

    //Ecoute les touches de clavier pour invoquer les differentes actions du joueur
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { LeftClick?.Invoke(); }

        // Input avant-arriere
        if (Input.GetKey(KeyCode.S)) { SPress?.Invoke(); }
        if (Input.GetKey(KeyCode.W)) { WPress?.Invoke(); }

        // Input droite-gauche
        if (Input.GetKey(KeyCode.D)) { DPress?.Invoke(); }
        if (Input.GetKey(KeyCode.A)) { APress?.Invoke(); }

        // Input frappe
        if (Input.GetKey(KeyCode.Space)) { SpcPress?.Invoke(); }
        if (Input.GetKeyUp(KeyCode.Space)) { SpcRelease?.Invoke(); }

        //Input triche
        if (Input.GetKey(KeyCode.Alpha1)) { OneTap?.Invoke(); }
        if (Input.GetKey(KeyCode.Alpha2)) { TwoTap?.Invoke(); }
        if (Input.GetKey(KeyCode.Alpha3)) { ThreeTap?.Invoke(); }
        if (Input.GetKey(KeyCode.Alpha9)) { NineTap?.Invoke(); }
        if (Input.GetKey(KeyCode.Alpha0)) { ZeroTap?.Invoke(); }

    }
}
