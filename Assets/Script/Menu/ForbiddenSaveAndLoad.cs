using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ForbiddenController : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        // 初始隐藏
        text.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        StartCoroutine(ShowTextCoroutine());
    }

    private IEnumerator ShowTextCoroutine()
    {
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); // 等待2秒

        text.gameObject.SetActive(false);
    }

}
