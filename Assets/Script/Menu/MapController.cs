using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject mapPanel; // 地图面板

    // 点击显示地图按钮
    public void ShowMap()
    {
        mapPanel.SetActive(true);
    }

    // 点击关闭按钮
    public void HideMap()
    {
        mapPanel.SetActive(false);
    }
}
