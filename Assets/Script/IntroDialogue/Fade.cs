using UnityEngine;

public class DelayedFadeOut : MonoBehaviour
{
    public float delay = 0.5f;
    public float fadeDuration = 1f;
    public GameObject Black;

    private Material fadeMaterial;
    private Color originalColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer found on object for fade effect.");
            return;
        }

        fadeMaterial = renderer.material;
        originalColor = fadeMaterial.color;

        StartCoroutine(FadeAfterDelay());
    }

    System.Collections.IEnumerator FadeAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // 🔒 全局锁输入
        InputBlocker.IsInputBlocked = true;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            Color newColor = originalColor;
            newColor.a = alpha;
            fadeMaterial.color = newColor;
            yield return null;
        }

        Color finalColor = originalColor;
        finalColor.a = 0f;
        fadeMaterial.color = finalColor;

        gameObject.SetActive(false);
        Black.gameObject.SetActive(false);

        // 🔓 恢复输入
        InputBlocker.IsInputBlocked = false;
    }
}
