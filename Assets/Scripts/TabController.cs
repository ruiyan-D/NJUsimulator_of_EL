using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Button[] mainTabs;       // 5 个主 Tab
    public GameObject[] mainPages;  // 对应 5 个 Panel

    void Start()
    {
        for (int i = 0; i < mainTabs.Length; i++)
        {
            int idx = i;
            mainTabs[i].onClick.AddListener(() => SwitchMain(idx));
        }
        SwitchMain(0);
    }

    void SwitchMain(int idx)
    {
        for (int i = 0; i < mainPages.Length; i++)
            mainPages[i].SetActive(i == idx);
    }
}
