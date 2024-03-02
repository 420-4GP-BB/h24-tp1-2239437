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
    [SerializeField] public UnityEngine.UI.Slider hitBar;
    private float changePerSecond = 0.7f;
    private bool chargeDirection = true;
    [SerializeField] private OutOfBounds outOfBounds;
    [SerializeField] private GameObject player;
    private int currentLevel;


    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S)) { hitForce = 0; hitBar.value = 0; }
        if (Input.GetKey(KeyCode.S)) { ChargeShot(); }

        if (Input.GetKey(KeyCode.Alpha0)) { CheatCodeZero(); }
        if (Input.GetKey(KeyCode.Alpha1)) { CheatCodeOne(); }
        if (Input.GetKey(KeyCode.Alpha2)) { CheatCodeTwo(); }
        if (Input.GetKey(KeyCode.Alpha3)) { CheatCodeThree(); }

    }

    private void OnEnable()
    {
        outOfBounds.OutOfBoundsCollision += OutOfBoundsCollision;
    }

    public void ChargeShot()
    {
        if (chargeDirection == true)
        {
            if (hitForce >= 1f) { chargeDirection = false; }
            else
            {
                hitForce += changePerSecond * Time.deltaTime;
                hitBar.value = hitForce;
            }
        }
        else
        {
            if (hitForce <= 0f) { chargeDirection = true; }
            else
            {
                hitForce -= changePerSecond * Time.deltaTime;
                hitBar.value = hitForce;
            }
        }
    }

    public void OutOfBoundsCollision() 
    {
        
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
    }

    private void CheatCodeTwo()
    {
        player.transform.position = new Vector3(-10f, .3f, -4f);
    }

    private void CheatCodeThree()
    {
        player.transform.position = new Vector3(-24f, .3f, -4f);
    }
}
