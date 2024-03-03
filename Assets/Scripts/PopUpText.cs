using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private OutOfBounds boundary;
    [SerializeField] private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        boundary.OutOfBoundsCollision += PenaltyPopUp;
    }

    //Lance un message de penalite
    private void PenaltyPopUp()
    {
        Debug.Log(text.text);
        StartCoroutine(Penalty());
    }
    IEnumerator Penalty()
    {
        text.text = "Balle Hors Terrain, Penalite +1";
        yield return new WaitForSeconds(2);
        text.text = "";
    }
}
