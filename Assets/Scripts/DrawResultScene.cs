using UnityEngine;
using TMPro;
using System.Collections;

public class DrawResultManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    void Start()
    {
        StartCoroutine(ShowDrawResult());
    }

    IEnumerator ShowDrawResult()
    {
        // 初始提示
        statusText.text = "成功提交选课结果！";

        // 模拟等待 2 秒
        yield return new WaitForSeconds(2f);

        // 这里可以替换为你的抽签逻辑
    }
}
