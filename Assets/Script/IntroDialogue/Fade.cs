using UnityEngine;

public class DelayedFadeOut : MonoBehaviour
{
    public float delay = 0.5f;         // 等待时间
    public float fadeDuration = 1f;   // 渐变时长
    public GameObject Black;

    private Material fadeMaterial;
    private Color originalColor;
    //private bool isFading = false;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer found on object for fade effect.");
            return;
        }

        // 创建材质实例防止修改全局材质
        fadeMaterial = renderer.material;
        originalColor = fadeMaterial.color;

        // 启动协程
        StartCoroutine(FadeAfterDelay());
    }

    System.Collections.IEnumerator FadeAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        //isFading = true;
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

        // 最终确保透明并关闭对象
        Color finalColor = originalColor;
        finalColor.a = 0f;
        fadeMaterial.color = finalColor;

        gameObject.SetActive(false);
        Black.gameObject.SetActive(false);
    }
}
