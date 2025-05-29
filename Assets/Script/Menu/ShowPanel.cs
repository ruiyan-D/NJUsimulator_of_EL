using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPanelController : MonoBehaviour
{
    public GameObject panel;          // 引用面板
    public TextMeshProUGUI textBox;   // 面板中的文字
    public Button showButton;         // 触发按钮

    private void Start()
    {
        // 确保面板初始隐藏
        panel.SetActive(false);

        // 绑定按钮点击事件
        showButton.onClick.AddListener(ShowPanel);
    }

    void ShowPanel()
    {
        panel.SetActive(true);
        //textBox.text = "欢迎来到南大新生引导系统！";
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
