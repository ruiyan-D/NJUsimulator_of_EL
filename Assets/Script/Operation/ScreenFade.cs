using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade instance;
    // 渐变参数
    public float fadeDuration = 1f;   // 渐变时间
    public float blackDuration = 2f;  // 黑屏持续时间
    
    private Texture2D blackTexture;    // 黑色纹理
    private float currentAlpha = 0f;   // 当前透明度
    private bool isFading = false;     // 是否正在渐变

    
    void Start()
    {
        // 创建1x1的黑色纹理
        blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();
    }
    
    void OnGUI()
    {
        if (currentAlpha > 0f)
        {
            // 设置颜色和透明度
            GUI.color = new Color(1f, 1f, 1f, currentAlpha);
            
            // 绘制全屏黑色纹理
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
        }
    }
    
    // 开始渐变效果（按钮调用）
    public void StartFadeEffect()
    {
        if (!isFading)
        {
            StartCoroutine(FadeRoutine());
        }
    }
    
    private IEnumerator FadeRoutine()
    {
        isFading = true;
        
        // 渐变到黑屏
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            currentAlpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
        currentAlpha = 1f;
        
        // 保持黑屏
        yield return new WaitForSeconds(blackDuration);
        
        // 渐变恢复
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }
        currentAlpha = 0f;
        
        isFading = false;
        NPCDateController.Instance.UpdateAllNPCs(PlayerStatus.instance.playingDate);
    }
}