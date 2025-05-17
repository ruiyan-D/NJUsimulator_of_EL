using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private static PositionManager _instance;
    public static PositionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PositionManager>();
                // 改进：如果找到多个实例，销毁多余的
                if (FindObjectsOfType<PositionManager>().Length > 1)
                {
                    Debug.LogError("Multiple PositionManager instances found. Destroying duplicates...");
                    var instances = FindObjectsOfType<PositionManager>();
                    for (int i = 1; i < instances.Length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }
                }
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(PositionManager).Name;
                    _instance = obj.AddComponent<PositionManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    //确认Player位置
    private Dictionary<string, bool> activePositions = new Dictionary<string, bool>();

    public void SetPositionActive(string id, bool isActive)
    {
        if (activePositions.ContainsKey(id))
        {
            activePositions[id] = isActive;
        }
        else
        {
            activePositions.Add(id, isActive);
        }
    }

    public bool IsPositionActive(string id)
    {
        return activePositions.ContainsKey(id) && activePositions[id];
    }

    // 存储每个场景对应的 Player 位置
    private Dictionary<string, Vector3> savedPositions = new Dictionary<string, Vector3>();

    // 保存当前位置
    public void SavePlayerPosition(string sceneName, Vector3 position)
    {
        savedPositions[sceneName] = position;
    }

    // 恢复位置
    public Vector3 GetSavedPosition(string sceneName)
    {
        if (savedPositions.ContainsKey(sceneName))
        {
            return savedPositions[sceneName];
        }

        // 修正：如果不存在记录，返回 Vector3.zero（默认原点）
        return Vector3.zero;
    }
}
