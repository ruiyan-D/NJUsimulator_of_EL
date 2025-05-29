using UnityEngine;

public class ReadingLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 PanelReading/Viewport/Content

    [Header("阅读课课程列表")]
    public string[] courses = {
        "《红楼梦》阅读",
        "《全球通史》阅读",
        "《理想国》阅读",
        "《国家竞争优势》阅读",
        "《时间简史》阅读",
        "《卓有成效的管理者》阅读"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("ReadingLoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            GameObject go = Instantiate(prefab, contentParent);

            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "Read");
            }
            else
            {
                Debug.LogError("ReadingLoader: prefab 上未找到 CourseItem 脚本！");
            }
        }
    }
}
