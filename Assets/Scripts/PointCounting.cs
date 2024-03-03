using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PointCounting : MonoBehaviour
{

    [SerializeField] private EventObserver _eventObserver;
    [SerializeField] private TextMeshProUGUI text;
    public event Action lvlDone;

    private int currentLvl = 1;
    private int currentPoints = 0;
    private int lvlOnePoints = 0;
    private int lvlTwoPoints = 0;
    private int lvlThreePoints = 0;


    // Start is called before the first frame update
    void Start()
    {
        _eventObserver.startLvlOne += StartLvlOne;
        _eventObserver.startLvlTwo += StartLvlTwo;
        _eventObserver.startLvlThree += StartLvlThree;
        _eventObserver.hasShot += HasShot;
        text.text = currentPoints.ToString();
    }

    private void Update()
    {
        if (currentPoints >= 7) 
        {
            LvlDone();
        }
    }

    private void StartLvlOne() { currentLvl = 1; }
    private void StartLvlTwo() { currentLvl = 2; }
    private void StartLvlThree() { currentLvl = 3; }

    private void HasShot() { currentPoints += 1; text.text = currentPoints.ToString(); }

    private void LvlDone() 
    {
        lvlDone?.Invoke();
        switch (currentLvl)
        {
            case 1:
                lvlOnePoints = currentPoints;
                currentPoints = 0;
                break;
            case 2:
                lvlTwoPoints = currentPoints;
                currentPoints = 0;
                break;
            case 3:
                lvlThreePoints = currentPoints;
                currentPoints = 0;
                break;
        }
    }
}
