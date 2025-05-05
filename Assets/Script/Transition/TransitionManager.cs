using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public void Transition(string from, string to)
    {
        StartCoroutine(TransitionToScene(from,to));
    }
    private IEnumerator TransitionToScene(string from,string to){
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(from);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        SceneManager.SetActiveScene(newScene);

        // 清理多余的 AudioListener
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        for (int i = 1; i < listeners.Length; i++)
        {
            listeners[i].enabled = false;
        }
    }
}
