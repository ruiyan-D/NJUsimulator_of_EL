using UnityEngine;

public class MajorLoader : MonoBehaviour
{
    [Header("课程项 Prefab")]
    public GameObject prefab;               // 拖入 CourseItemTemplate Prefab

    [Header("内容容器（ScrollView Content）")]
    public Transform contentParent;         // 拖入 MajorScrollView/Viewport/Content

    [Header("专业课课程列表")]
    public string[] courses = {
        "信息科学中的物理学", "c语言程序设计基础"
    };

    void Start()
    {
        Debug.Log($"MajorLoader，courses 长度 = {courses.Length}");
        // 遍历课程名数组，为每门课实例化一个按钮
        foreach (var courseName in courses)
        {
            // 1. 实例化一个按钮，父对象设为 contentParent
            GameObject go = Instantiate(prefab, contentParent);

            // 2. 通过 CourseItem 脚本设置显示文本和板块标识
            var item = go.GetComponent<CourseItem>();
            item.Initialize(courseName, "Major");
        }
    }
}
