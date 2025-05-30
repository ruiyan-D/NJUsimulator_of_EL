using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataSaver : MonoBehaviour
{
    [SerializeField] public PlayerStatus playerData;
    private bool _initialized = false;

    // 场景重载数据存储
    public static string ReloadPlayerJson { get; private set; }

    private void Start()
    {
        // 初始化引用
        if (playerData == null)
        {
            playerData = FindObjectOfType<PlayerStatus>();
            if (playerData != null) _initialized = true;
        }
        
        // 应用重载数据（如果有）
        if (!string.IsNullOrEmpty(ReloadPlayerJson) && playerData != null)
        {
            JsonUtility.FromJsonOverwrite(ReloadPlayerJson, playerData);

            playerData.LoadFromSavedList();

            Debug.Log("应用重载数据到PlayerStatus");
            ReloadPlayerJson = null; // 清除数据
        }
    }

    public void saveData()
    {
        if (playerData == null)
        {
            Debug.LogError("保存失败：无PlayerStatus引用");
            return;
        }

        playerData.PrepareForSave();

        string jsonData = JsonUtility.ToJson(playerData);
        string dataPath = Path.Combine(Application.persistentDataPath, "SeapeanSaveFile.json");

        try
        {
            File.WriteAllText(dataPath, jsonData);
            Debug.Log("数据保存成功");
        }
        catch (System.Exception e)
        {
            Debug.LogError("保存失败: " + e.Message);
        }
    }

    public void getData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "SeapeanSaveFile.json");
        
        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                
                // 保存到重载数据
                ReloadPlayerJson = jsonData;
                
                // 重载场景
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"读取失败: {e.Message}");
            }
        }
        else
        {
            Debug.LogWarning("存档文件不存在");
        }
    }
}