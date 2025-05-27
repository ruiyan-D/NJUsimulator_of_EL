using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 静态实例
    private static GameManager instance;

    void Awake()
    {
        // 检查是否已经有实例存在
        if (instance != null && instance != this)
        {
            //Debug.Log("发现已有 Persistent 实例，销毁新加载的");
            Destroy(gameObject); // 销毁新的
        }
        else
        {
            //Debug.Log("初始化 Persistent 实例");
            instance = this;
            DontDestroyOnLoad(gameObject); // 保留当前的
        }
    }
}
