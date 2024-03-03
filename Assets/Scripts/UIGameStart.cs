using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    [SerializeField] private KeyLogger _keyLogger;
    public TextMeshProUGUI startText;
    public GameObject overheadCamera;
    public GameObject playerCamera;
    bool fadeDone = false;

    public event Action gameStart;

    //Demmare la coroutine du texte de debut
    void Start()
    {
        _keyLogger.LeftClick += CommencerPartie;
        StartCoroutine(FadeInText(startText));
    }

    void Update()
    {
        if (fadeDone)
        {
            CommencerPartie();
        }
    }

    //Efface le texte puis change la camera
    private void CommencerPartie()
    {
        fadeDone = true;
        startText.alpha = -1;
        playerCamera.SetActive(true);
        overheadCamera.SetActive(false);
        gameStart?.Invoke();
    }

    private IEnumerator FadeInText(TextMeshProUGUI text)
    {

        if (fadeDone == false)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2));
                yield return null;
            }
            yield return new WaitForSeconds(1f);

        }
        fadeDone = true;
    }
}
