using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ballControler : MonoBehaviour
{
    public float hitForce = 0f;
    [SerializeField] private GameObject hitBar;
    private float changePerSecond = 0.7f;
    private bool chargeDirection = true;
    [SerializeField] private OutOfBounds outOfBounds;
    [SerializeField] private GameObject player;
    private int currentLevel = 1;

    public event Action CameraCloser; 
    public event Action CameraFurther;


    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { 
            hitForce = 0;
            hitBar.transform.localScale = new Vector3(0.2f, 0f, 0.1f);   
            hitBar.SetActive(false); 
        }
        if (Input.GetKey(KeyCode.Space)) { ChargeShot(); }

        if (Input.GetKey(KeyCode.S)) { CameraFurther?.Invoke(); }
        if (Input.GetKey(KeyCode.W)) { CameraCloser?.Invoke(); }

        if (Input.GetKey(KeyCode.Alpha0)) { CheatCodeZero(); }
        if (Input.GetKey(KeyCode.Alpha1)) { CheatCodeOne(); }
        if (Input.GetKey(KeyCode.Alpha2)) { CheatCodeTwo(); }
        if (Input.GetKey(KeyCode.Alpha3)) { CheatCodeThree(); }
        if (Input.GetKey(KeyCode.Alpha9)) { CheatCodeNine(); }

    }

    private void OnEnable()
    {
        outOfBounds.OutOfBoundsCollision += OutOfBoundsCollision;
    }

    public void ChargeShot()
    {
        hitBar.SetActive(true);

        if (chargeDirection == true)
        {
            if (hitForce >= 1f) { chargeDirection = false; }
            else
            {
                hitForce += changePerSecond * Time.deltaTime;
                hitBar.transform.localScale += new Vector3(0,1,0) * changePerSecond * Time.deltaTime;
            }
        }
        else
        {
            if (hitForce <= 0f) { chargeDirection = true; }
            else
            {
                hitForce -= changePerSecond * Time.deltaTime;
                hitBar.transform.localScale -= new Vector3(0, 1, 0) * changePerSecond * Time.deltaTime;
            }
        }
    }

    public void OutOfBoundsCollision() 
    {
        switch (currentLevel)
        {
            case 1:
                player.transform.position = new Vector3(-1.5f, .3f, -4f);
                break;
            case 2:
                player.transform.position = new Vector3(-10f, .3f, -4f);
                break;
            case 3:
                player.transform.position = new Vector3(-24f, .3f, -4f);
                break;
        }
    }

    private void CheatCodeZero() 
    { 
        switch (currentLevel)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
        }
    }

    private void CheatCodeOne()
    {
        player.transform.position = new Vector3(-1.5f, .3f, -4f);
        currentLevel = 1;
    }

    private void CheatCodeTwo()
    {
        player.transform.position = new Vector3(-10f, .3f, -4f);
        currentLevel = 2;
    }

    private void CheatCodeThree()
    {
        player.transform.position = new Vector3(-24f, .3f, -4f);
        currentLevel = 3;
    }
    private void CheatCodeNine()
    {
        player.transform.position = new Vector3(0, 1f, -6f);
    }
}
