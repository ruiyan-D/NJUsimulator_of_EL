using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    [SerializeField]
    public PlayerStatus playerData ;

    private void Awake()
    {
        Transform paTransform = GameManager.instance.transform;
        Transform kidTransform = paTransform.Find("PlayerStatus");
        if (kidTransform != null)
        {
            GameObject temp = kidTransform.gameObject;
            playerData = temp.GetComponent<PlayerStatus>();
        }
    }

    public void saveData()
    {
        
        string jsonData = JsonUtility.ToJson(playerData);
        string dataPath = Path.Combine(Application.persistentDataPath, "SeapeanSaveFile.json");

        try
        {
            File.WriteAllText(dataPath, jsonData);
            Debug.Log("数据保存成功！路径：" + dataPath);
            Debug.Log("存档数据：" + jsonData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("保存失败: " + e.Message);
        }
    }

    public void getData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "SeapeanSaveFile.json");
        Transform paTransform = GameManager.instance.transform;
        Transform kidTransform = paTransform.Find("PlayerStatus");
        PlayerStatus target = kidTransform.GetComponent<PlayerStatus>();
    
        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                PlayerStatus loadedData = JsonUtility.FromJson<PlayerStatus>(jsonData);
                target = loadedData;
            }
            catch (System.Exception e)
            {
                Debug.LogError("读取失败: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("存档文件不存在");
        }
    }
}
