using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public float fadeTime;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.alpha = Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) { text.CrossFadeAlpha(1.0f, 0.001f, false); }
    }
}
