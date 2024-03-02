using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject overheadCamera;
    public GameObject playerCamera;
    bool fadeDone = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInText(text));
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeDone || Input.GetMouseButtonDown(0)) 
        {
            fadeDone = true;
            text.alpha = -1;
            playerCamera.SetActive(true);
            overheadCamera.SetActive(false);
        }
    }

    private IEnumerator FadeInText(TextMeshProUGUI text)
    {
        
        if (fadeDone == false) 
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime/2));
                yield return null;
            }
            yield return new WaitForSeconds(1f);
           
        }
        fadeDone = true;
    }
}
