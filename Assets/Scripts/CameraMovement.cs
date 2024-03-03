using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private KeyLogger _keyLogger;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject target;

    private void OnEnable()
    {
        _keyLogger.WPress += CameraCloser;
        _keyLogger.SPress += CameraFurther;

        _keyLogger.APress += TurnLeft;
        _keyLogger.DPress += TurnRight;
    }

    //Tourne la camera a droite
    private void TurnRight()
    {
        camera.transform.RotateAround(target.transform.position, new Vector3(0f, 1f, 0f), 1f);
    }

    //Tourne la camera a gauche
    private void TurnLeft()
    {
        camera.transform.RotateAround(target.transform.position, new Vector3(0f, 1f, 0f), -1f);
    }

    //Rapproche la camera 
    private void CameraCloser()
    {
        camera.transform.position += camera.transform.forward * Time.deltaTime;
    }

    //Eloigne la camera
    private void CameraFurther()
    {
        camera.transform.position -= camera.transform.forward * Time.deltaTime;
    }

}
