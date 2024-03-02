using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private ballControler player;
    [SerializeField] private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        player.CameraCloser += CameraCloser;
        player.CameraFurther += CameraFurther;
    }

    private void CameraCloser() 
    {
        camera.transform.position += new Vector3(0f, -0.2f, 1f) * Time.deltaTime;
    }

    private void CameraFurther() 
    {
        camera.transform.position -= new Vector3(0f, -0.2f, 1f) * Time.deltaTime;
    }

}
