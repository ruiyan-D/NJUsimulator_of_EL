using UnityEngine;

public class CrossLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 PanelCross/Viewport/Content

    [Header("通修课课程列表")]
    public string[] courses = {
        "微积分",
        "线性代数",
        "英语听说",
        "英语读写",
        "Python 编程"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("CrossLoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            // 1) 实例化一个课程按钮
            GameObject go = Instantiate(prefab, contentParent);

            // 2) 通过 CourseItem 脚本初始化名称和所属板块 key="Cross"
            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "Cross");
            }
            else
            {
                Debug.LogError("CrossLoader: 实例化的 Prefab 上找不到 CourseItem 脚本！");
            }
        }
    }
}
