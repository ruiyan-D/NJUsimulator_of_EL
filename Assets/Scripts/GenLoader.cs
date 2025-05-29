using UnityEngine;

public class GenLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;            // 拖入 CourseItemPrefab

    [Header("ScrollView Content")]
    public Transform contentParent;      // 拖入 SubPanelGen/Viewport/Content

    [Header("通识课课程列表")]
    public string[] courses = {
        "宇宙简史",
        "南大逸事",
        "大美汉字",
        "大学生形象与礼仪",
        "积极心理与个人成长",
        "人工智能下的数据思维",
        "微生物与人类健康",
        "汉英语言对比：文化与认知考量",
        "人类语言与人工智能语言模型",
        "胜解《孙子兵法》",
        "遗传密码——认识自我和生命",
        "艺术解读"
    };

    void Start()
    {
        if (prefab == null || contentParent == null)
        {
            Debug.LogError("GenLoader: prefab 或 contentParent 未设置！");
            return;
        }

        foreach (var courseName in courses)
        {
            // 实例化课程按钮，并设置到 contentParent 下
            GameObject go = Instantiate(prefab, contentParent);

            // 初始化 CourseItem：显示文字 & 指定板块 key = "Gen"
            var item = go.GetComponent<CourseItem>();
            if (item != null)
            {
                item.Initialize(courseName, "Gen");
            }
            else
            {
                Debug.LogError("GenLoader: 实例化的 Prefab 上找不到 CourseItem 脚本！");
            }
        }
    }
}
