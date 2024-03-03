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
    public event Action tooManyHits;
    public event Action holeInOne;
    public event Action<int, int, int> gameDone;

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
        _eventObserver.outOfBoundsCollision += Penalty;
        _eventObserver.hasShot += HasShot;
        _eventObserver.lvlDone += LvlDone;
        _eventObserver.gameDone += GameDone;
        text.text = currentPoints.ToString();
    }

    private void Update()
    {
        if (currentPoints >= 8)
        {
            LvlDone();
            lvlDone?.Invoke();
            tooManyHits?.Invoke();
        }
    }

    private void StartLvlOne() { currentLvl = 1; currentPoints = 0; text.text = currentPoints.ToString(); }
    private void StartLvlTwo() { currentLvl = 2; currentPoints = 0; text.text = currentPoints.ToString(); }
    private void StartLvlThree() { currentLvl = 3; currentPoints = 0; text.text = currentPoints.ToString(); }

    private void Penalty() { currentPoints += 1; }

    private void HasShot() { currentPoints += 1; text.text = currentPoints.ToString(); }

    private void LvlDone()
    {
        if (currentPoints == 1) { holeInOne?.Invoke(); }

        switch (currentLvl)
        {
            case 1:
                lvlOnePoints = currentPoints;
                currentPoints = 0;
                text.text = currentPoints.ToString();
                currentLvl = 2;
                break;
            case 2:
                lvlTwoPoints = currentPoints;
                currentPoints = 0;
                text.text = currentPoints.ToString();
                currentLvl = 3;
                break;
            case 3:
                lvlThreePoints = currentPoints;
                currentPoints = 0;
                break;
        }
    }

    private void GameDone() 
    { 
        text.text = "";
        gameDone?.Invoke(lvlOnePoints, lvlTwoPoints, lvlThreePoints);
    }
}
