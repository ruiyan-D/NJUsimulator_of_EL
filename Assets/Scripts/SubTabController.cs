using UnityEngine;
using UnityEngine.UI;

public class SubTabController : MonoBehaviour
{
    [Header("子标签按钮（通识／科学之光／美育）")]
    public Button[] subTabs;           // 拖入 BtnGen, BtnSci, BtnArt

    [Header("子面板（SubPanelGen／SubPanelSci／SubPanelArt）")]
    public GameObject[] subPages;      // 拖入对应的 SubPanel

    private int currentIndex = 0;

    void Start()
    {
        // 为每个按钮绑定点击切换事件
        for (int i = 0; i < subTabs.Length; i++)
        {
            int idx = i;  // 避免闭包问题
            subTabs[i].onClick.AddListener(() => SwitchSubTab(idx));
        }

        // 初始只显示第一个子面板
        SwitchSubTab(0);
    }

    /// <summary>
    /// 切换到第 idx 个子面板
    /// </summary>
    void SwitchSubTab(int idx)
    {
        for (int i = 0; i < subPages.Length; i++)
        {
            subPages[i].SetActive(i == idx);
        }
        currentIndex = idx;
    }
}
