using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    private bool isFade;
    public GameObject playerPrefab; // 预制体

    public void Transition(string from, string to)
    {
        if (!isFade)
            StartCoroutine(TransitionToScene(from, to));
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        // 保存当前位置
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if (currentPlayer != null)
        {
            PositionManager.Instance.SavePlayerPosition(from, currentPlayer.transform.position);
        }

        yield return Fade(1); // black
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Single);

        Scene newScene = SceneManager.GetSceneByName(to);
        SceneManager.SetActiveScene(newScene);

        // 找到新的 Player
        GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");

        // 如果没有找到，实例化一个
        if (newPlayer == null && playerPrefab != null)
        {
            newPlayer = Instantiate(playerPrefab);
            newPlayer.name = "Player";
        }

        // 设置 Player 位置
        Vector3 savedPosition = PositionManager.Instance.GetSavedPosition(to);
        if (savedPosition != Vector3.zero)
        {
            newPlayer.transform.position = savedPosition;
        }

        yield return Fade(0); // white
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}
