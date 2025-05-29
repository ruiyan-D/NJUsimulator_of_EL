using UnityEngine;

public class SciLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 SubPanelSci/Viewport/Content

    [Header("“科学之光”课程列表")]
    public string[] courses = {
        "智能科技与未来城市",
        "认识与战胜疾病",
        "物理改变世界",
        "探索生命：从分子运动到人工智能",
        "自然地理学新发现",
        "先进功能材料——现代工程之“芯”"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("SciLoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            // 实例化课程按钮，并设置到 contentParent 下
            GameObject go = Instantiate(prefab, contentParent);

            // 初始化 CourseItem：显示文字 & 指定板块 key = "Sci"
            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "Sci");
            }
            else
            {
                Debug.LogError("SciLoader: 实例化的 Prefab 上找不到 CourseItem 脚本！");
            }
        }
    }
}
