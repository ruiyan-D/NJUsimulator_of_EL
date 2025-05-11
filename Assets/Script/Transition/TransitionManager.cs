using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    private bool isFade;

    public void Transition(string from, string to)
    {
        if(!isFade)
            StartCoroutine(TransitionToScene(from,to));
    }
    private IEnumerator TransitionToScene(string from,string to){
        yield return Fade(1);//black
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(from);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0);//white

        // 清理多余的 AudioListener
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        for (int i = 1; i < listeners.Length; i++)
        {
            listeners[i].enabled = false;
        }
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha-targetAlpha)/fadeDuration;
        while(!Mathf.Approximately(fadeCanvasGroup.alpha,targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha,targetAlpha,speed*Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}
