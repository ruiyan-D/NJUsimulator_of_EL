using UnityEngine;

public class WarningPopupController : MonoBehaviour
{
    public GameObject warningPanel;

    public void ShowWarning(string message)
    {
        // 设置提示内容
        TMPro.TextMeshProUGUI text = warningPanel.transform.Find("WarningText").GetComponent<TMPro.TextMeshProUGUI>();
        text.text = message;

        // 显示弹窗
        warningPanel.SetActive(true);
    }

    public void HideWarning()
    {
        warningPanel.SetActive(false);
    }
}
