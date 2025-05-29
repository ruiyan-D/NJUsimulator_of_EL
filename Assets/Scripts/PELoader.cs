using UnityEngine;

public class PELoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 PanelPE/Viewport/Content

    [Header("体育课课程列表")]
    public string[] courses = {
        "羽毛球",
        "篮球",
        "体适能",
        "游泳",
        "减脂理论与实践",
        "体育舞蹈",
        "传统导引术"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("PELoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            // 实例化一个课程按钮
            GameObject go = Instantiate(prefab, contentParent);

            // 通过 CourseItem 脚本初始化：设置文字 & 板块 key = "PE"
            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "PE");
            }
            else
            {
                Debug.LogError("PELoader: 实例化的 Prefab 上找不到 CourseItem 脚本！");
            }
        }
    }
}
