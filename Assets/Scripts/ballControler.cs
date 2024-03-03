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
    [SerializeField] private KeyLogger _keyLogger;
    [SerializeField] private EventObserver _eventObserver;

    public event Action startLvlOne;
    public event Action startLvlTwo;
    public event Action startLvlThree;
    public event Action hasShot;
    public event Action gameDone;

    [SerializeField] private GameObject hitBar;
    private float hitForce = 0f;
    private float changePerSecond = 0.7f;
    private bool chargeDirection = true;
    private bool canShoot = true;
    private bool gameStart = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera camera;

    private int currentLevel = 1;

    private Vector3 oldPosition;
    

    void Start()
    {
        oldPosition = ball.transform.position;
        StartCoroutine(CheckPosition());

        _eventObserver.gameStart += GameStart;
        _eventObserver.outOfBoundsCollision += OutOfBoundsCollision;
        _eventObserver.startLvlOne += StartLvlOne;
        _eventObserver.startLvlTwo += StartLvlTwo;
        _eventObserver.startLvlThree += StartLvlThree;
        _eventObserver.lvlDone += LvlDone;

        _keyLogger.SpcPress += ChargeShot;
        _keyLogger.SpcRelease += Shoot;

        _keyLogger.ZeroTap += CheatCodeZero;
        _keyLogger.OneTap += CheatCodeOne;
        _keyLogger.TwoTap += CheatCodeTwo;
        _keyLogger.ThreeTap += CheatCodeThree;
        _keyLogger.NineTap += CheatCodeNine;
    }

    void Update()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, ball.transform.position, 10f);

        
    }

    private void GameStart() { gameStart = true; }

    //Charge le tir
    public void ChargeShot()
    {
        if (canShoot && gameStart) 
        {
            hitBar.SetActive(true);

            if (chargeDirection == true)
            {
                if (hitForce >= 1f) { chargeDirection = false; }
                else
                {
                    hitForce += changePerSecond * Time.deltaTime;
                    hitBar.transform.localScale += new Vector3(0, 1, 0) * changePerSecond * Time.deltaTime;
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
    }

    //Lance le tir
    public void Shoot()
    {
        if (canShoot && gameStart)
        {
            rb.AddForce(camera.transform.forward * (hitForce * 8f), ForceMode.Impulse);
            hitBar.transform.localScale = new Vector3(0.2f, 0f, 0.1f);
            hitForce = 0;
            hitBar.SetActive(false);
            hasShot?.Invoke();
            canShoot = false;
        }
    }

    //Transporte le joueur apres etre sorti du terrain
    public void OutOfBoundsCollision()
    {
        switch (currentLevel)
        {
            case 1:
                rb.isKinematic = true;
                ball.transform.position = new Vector3(-1.5f, .3f, -4f);
                player.transform.position = new Vector3(-1.5f, .3f, -4f);
                rb.isKinematic = false;
                break;
            case 2:
                rb.isKinematic = true;
                ball.transform.position = new Vector3(-10f, .3f, -4f);
                player.transform.position = new Vector3(-10f, .3f, -4f);
                rb.isKinematic = false;
                break;
            case 3:
                rb.isKinematic = true;
                ball.transform.position = new Vector3(-24f, .3f, -4f);
                player.transform.position = new Vector3(-24f, .3f, -4f);
                rb.isKinematic = false;
                break;
        }
    }

    //Code triche 0
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

    //Code triche 1
    private void CheatCodeOne()
    {
        rb.isKinematic = true;
        player.transform.position = new Vector3(-1.5f, .3f, -4f);
        ball.transform.position = new Vector3(-1.5f, .3f, -4f);
        rb.isKinematic = false;
        currentLevel = 1;
        startLvlOne?.Invoke();
    }

    //Code triche 2
    private void CheatCodeTwo()
    {
        rb.isKinematic = true;
        player.transform.position = new Vector3(-10f, .3f, -4f);
        ball.transform.position = new Vector3(-10f, .3f, -4f);
        rb.isKinematic = false;
        currentLevel = 2;
        startLvlTwo?.Invoke();
    }

    //Code triche 3
    private void CheatCodeThree()
    {
        rb.isKinematic = true;
        player.transform.position = new Vector3(-24f, .3f, -4f);
        ball.transform.position = new Vector3(-24f, .3f, -4f);
        rb.isKinematic = false;
        currentLevel = 3;
        startLvlThree?.Invoke();
    }

    //Code triche 9
    private void CheatCodeNine()
    {
        rb.isKinematic = true;
        player.transform.position = new Vector3(0f, 1f, -7f);
        ball.transform.position = new Vector3(0f, 1f, -7f);
        rb.isKinematic = false;
    }

    private void StartLvlOne() { currentLevel = 1; }
    private void StartLvlTwo() { currentLevel = 2; }
    private void StartLvlThree() { currentLevel = 3; }

    private void LvlDone() 
    {
        switch (currentLevel) 
        {
            case 1:
                rb.isKinematic = true;
                player.transform.position = new Vector3(-10f, .3f, -4f);
                ball.transform.position = new Vector3(-10f, .3f, -4f);
                rb.isKinematic = false;
                currentLevel = 2;
                startLvlTwo?.Invoke();
                break;
            case 2:
                rb.isKinematic = true;
                player.transform.position = new Vector3(-24f, .3f, -4f);
                ball.transform.position = new Vector3(-24f, .3f, -4f);
                rb.isKinematic = false;
                currentLevel = 3;
                startLvlThree?.Invoke();
                break;
            case 3:
                gameDone?.Invoke();
                break;
        
        }
    }

    IEnumerator CheckPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            Vector3 newPosition = ball.transform.position;

            if (oldPosition == newPosition)
            {
                canShoot = true;
            }

            oldPosition = newPosition;
        }
    }
}
