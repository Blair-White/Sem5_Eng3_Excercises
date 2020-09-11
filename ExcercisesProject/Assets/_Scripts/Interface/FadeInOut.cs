using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private bool FadeOut, FadeIn, FadeComplete;
    private float mAlpha;
    
    // Start is called before the first frame update
    void Start()
    {
        FadeIn = true;
        mAlpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeIn)
        {
            if (mAlpha > 0)
            {
                mAlpha -= 0.001f;
                this.GetComponent<Image>().color =
                    new Color(0, 0, 0, mAlpha);
            }
            else
            { FadeIn = false; }
        }

        if (FadeOut)
        {
            if (mAlpha < 1)
            {
                mAlpha += 0.001f;
                this.GetComponent<Image>().color =
                    new Color(0, 0, 0, mAlpha);
            }
            else
            {
                GameObject sManager = GameObject.Find("SceneController");
                sManager.GetComponent<SceneController>().ChangeReady = true;
                FadeOut = false;
            }

        }

    }

    void FadeOutNow()
    {
        FadeOut = true;
        FadeIn = false;
    }
    void FadeInNow()
    {
        FadeIn = true;
        FadeOut = false;
    }
}
