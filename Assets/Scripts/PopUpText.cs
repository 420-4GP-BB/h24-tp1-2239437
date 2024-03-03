using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private OutOfBounds boundary;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject overheadCamera;
    [SerializeField] private GameObject playerCamera;

    private bool skip = true;

    [SerializeField] private EventObserver _eventObserver;


    // Start is called before the first frame update
    void Start()
    {
        boundary.OutOfBoundsCollision += PenaltyPopUp;
        _eventObserver.tooManyHits += TooManyHitsPopUp;
        _eventObserver.holeInOne += HoleInOnePopUp;
        _eventObserver.gameDonePoints += GameDonePopUp;
    }

    //Lance un message de penalite
    private void PenaltyPopUp() { StartCoroutine(Penalty()); }
    IEnumerator Penalty()
    {
        text.text = "Balle Hors Terrain, Penalite +1";
        yield return new WaitForSeconds(2);
        text.text = "";
    }

    private void TooManyHitsPopUp() { StartCoroutine(TooManyHits()); }
    IEnumerator TooManyHits()
    {
        text.text = "Limite de coups excedee :(";
        yield return new WaitForSeconds(2);
        text.text = "";
    }

    private void HoleInOnePopUp() { StartCoroutine(HoleInOne()); }
    IEnumerator HoleInOne()
    {
        text.text = "Trou D'un Coup !";
        yield return new WaitForSeconds(2);
        text.text = "";
    }

    private void GameDonePopUp(int points1, int points2, int points3) 
    {
        
        StartCoroutine(GameDone(points1, points2, points3));
        StartCoroutine(Skip(points1, points2, points3));
            
    }

    IEnumerator GameDone(int points1, int points2, int points3) 
    {
        playerCamera.transform.position = overheadCamera.transform.position;
        playerCamera.transform.rotation = overheadCamera.transform.rotation;

        text.text = "SCORE FINAL";
        yield return new WaitForSeconds(1);
        text.text = "SCORE FINAL\n" + points1;
        yield return new WaitForSeconds(1);
        text.text = "SCORE FINAL\n" + points1 + "  " + points2;
        yield return new WaitForSeconds(1);
        text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3;
        
        int scoreTotal = points1 + points2 + points3;

        switch (scoreTotal) 
        {
            case 3:
                text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n EXCELLENT";
                break;
            case 4:
            case 5:
            case 6:
                text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n TRES BIEN";
                break;
            case 7:
            case 8:
            case 9:
                text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n PAS MAL";
                break;
            default:
                text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n PAS TERRIBLE...";
                break;    
        
        }
        
    }

    IEnumerator Skip(int points1, int points2, int points3) 
    {
        int scoreTotal = points1 + points2 + points3;
        while (skip) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(GameDone(points1, points2, points3));

                switch (scoreTotal)
                {
                    case 3:
                        text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n EXCELLENT";
                        break;
                    case 4:
                    case 5:
                    case 6:
                        text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n TRES BIEN";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n PAS MAL";
                        break;
                    default:
                        text.text = "SCORE FINAL\n" + points1 + "  " + points2 + "  " + points3 + "\n PAS TERRIBLE...";
                        break;

                }
            }
            yield return null;
        }
    }
}
