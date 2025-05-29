using UnityEngine;

public class ArtLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 SubPanelArt/Viewport/Content

    [Header("美育课课程列表")]
    public string[] courses = {
        "工艺人文",
        "视觉人文",
        "音乐人文",
        "文学人文",
        "媒体人文",
        "戏剧人文"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("ArtLoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            // 1) 实例化一个课程按钮
            GameObject go = Instantiate(prefab, contentParent);

            // 2) 初始化 CourseItem：显示文字 & 指定板块 key = "Art"
            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "Art");
            }
            else
            {
                Debug.LogError("ArtLoader: 在实例化的 Prefab 上找不到 CourseItem 脚本！");
            }
        }
    }
}
