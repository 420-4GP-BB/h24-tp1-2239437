using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObserver : MonoBehaviour
{
    [SerializeField] private OutOfBounds outOfBounds; 
    public event Action outOfBoundsCollision;

    [SerializeField] private TextFade _gameStart;
    public event Action gameStart;

    [SerializeField] private ballControler _player;
    public event Action startLvlOne;
    public event Action startLvlTwo;
    public event Action startLvlThree;
    public event Action hasShot;
    public event Action gameDone;

    [SerializeField] private PointCounting _pointCounting;
    public event Action lvlDone;

    void Start()
    {
        outOfBounds.OutOfBoundsCollision += OutOfBoundsCollision;
        _gameStart.gameStart += GameStart;
        _player.startLvlOne += StartLvlOne;
        _player.startLvlOne += StartLvlTwo;
        _player.startLvlOne += StartLvlThree;
        _player.hasShot += HasShot;
        _player.gameDone += GameDone;
        _pointCounting.lvlDone += LvlDone;
    }

    private void OutOfBoundsCollision() { outOfBoundsCollision?.Invoke(); }

    private void GameStart() { gameStart?.Invoke(); }

    private void StartLvlOne() { startLvlOne?.Invoke(); }
    private void StartLvlTwo() { startLvlTwo?.Invoke(); }
    private void StartLvlThree() { startLvlThree?.Invoke(); }

    private void HasShot() { hasShot?.Invoke(); }

    private void LvlDone() { lvlDone?.Invoke(); }

    private void GameDone() { gameDone?.Invoke(); }

    // Update is called once per frame
    void Update()
    {
        
    }
}
