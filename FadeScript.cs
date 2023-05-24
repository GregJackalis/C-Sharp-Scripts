using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingImage;

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (loadingImage.alpha < 1)
            {
                loadingImage.alpha += Time.deltaTime;
                if (loadingImage.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (loadingImage.alpha >= 0)
            {
                loadingImage.alpha -= Time.deltaTime;
                if (loadingImage.alpha == 0)
                {
                    fadeIn = false;
                }
            }
        }
    }
}