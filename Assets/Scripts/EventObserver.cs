using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObserver : MonoBehaviour
{
    [SerializeField] private OutOfBounds outOfBounds;
    public event Action outOfBoundsCollision;

    [SerializeField] private HoleCollision _holeOne;
    [SerializeField] private HoleCollision _holeTwo;
    [SerializeField] private HoleCollision _holeThree;

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
    public event Action tooManyHits;
    public event Action holeInOne;
    public event Action<int, int, int> gameDonePoints;

    void Start()
    {
        outOfBounds.OutOfBoundsCollision += OutOfBoundsCollision;

        _holeOne.HoleTriggerEnter += LvlDone;
        _holeTwo.HoleTriggerEnter += LvlDone;
        _holeThree.HoleTriggerEnter += LvlDone;

        _gameStart.gameStart += GameStart;

        _player.startLvlOne += StartLvlOne;
        _player.startLvlOne += StartLvlTwo;
        _player.startLvlOne += StartLvlThree;
        _player.hasShot += HasShot;
        _player.gameDone += GameDone;

        _pointCounting.lvlDone += LvlDone;
        _pointCounting.tooManyHits += TooManyHits;
        _pointCounting.holeInOne += HoleInOne;
        _pointCounting.gameDone += GameDonePoints;

    }

    private void OutOfBoundsCollision() { outOfBoundsCollision?.Invoke(); }

    private void GameStart() { gameStart?.Invoke(); }

    private void StartLvlOne() { startLvlOne?.Invoke(); }
    private void StartLvlTwo() { startLvlTwo?.Invoke(); }
    private void StartLvlThree() { startLvlThree?.Invoke(); }

    private void HasShot() { hasShot?.Invoke(); }

    private void LvlDone() { lvlDone?.Invoke(); }

    private void TooManyHits() { tooManyHits?.Invoke(); }

    private void HoleInOne() { holeInOne?.Invoke(); }

    private void GameDone() { gameDone?.Invoke(); }

    private void GameDonePoints(int points1, int points2, int points3) { gameDonePoints.Invoke(points1, points2, points3); }

    // Update is called once per frame
    void Update()
    {

    }
}
