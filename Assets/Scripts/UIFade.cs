using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public Image fadeScreen;
    [SerializeField] float fadeTime;
    [SerializeField] bool fadeToBlack, fadeFromBlack;
    public static UIFade instance;


    void Start()
    {
        
    }

    void Update()
    {
        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeTime * Time.deltaTime));

            if (fadeScreen.color.a == 1)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeTime * Time.deltaTime));
                if (fadeScreen.color.a == 0)
                {
                    fadeFromBlack = false;
                }
        }
    }

    public void FadeToBlack()
    {
        fadeFromBlack = false;
        fadeToBlack = true;        
    }

    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;        
    }
}
