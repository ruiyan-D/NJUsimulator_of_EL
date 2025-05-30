using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forFinalStatement : MonoBehaviour
{
    public GameObject panel;
    public void OnClick()
    {
        panel.SetActive(true);
    }

    public void OnClick2()
    {
        ScreenFade.instance.StartFadeEffect();
        gameObject.SetActive(false);
    }

    public void OnClick3()
    {
        PlayerStatus.instance.playingDate++;
    }
}
