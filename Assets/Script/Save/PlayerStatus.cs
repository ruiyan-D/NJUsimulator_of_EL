using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedPositionEntry
{
    public string sceneName;
    public SerializableVector3 position;
}

[System.Serializable]
public class SerializableVector3
{
    public float x, y, z;
    public SerializableVector3(Vector3 v) { x = v.x; y = v.y; z = v.z; }
    public Vector3 ToVector3() => new Vector3(x, y, z);
}

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    public int Points;
    [SerializeField]
    public Tasks[] tasks;

    public string lastSceneBeforeMenu = null;
    public string studentId;
    public string playerName;
    public int playingDate;

    [System.NonSerialized]
    public Dictionary<string, Vector3> savedPositions = new Dictionary<string, Vector3>();

    // 序列化用中间字段
    public List<SavedPositionEntry> savedPositionsList = new List<SavedPositionEntry>();

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PrepareForSave()
    {
        savedPositionsList.Clear();
        foreach (var kvp in savedPositions)
        {
            savedPositionsList.Add(new SavedPositionEntry
            {
                sceneName = kvp.Key,
                position = new SerializableVector3(kvp.Value)
            });
        }
    }

    public void LoadFromSavedList()
    {
        savedPositions.Clear();
        foreach (var entry in savedPositionsList)
        {
            savedPositions[entry.sceneName] = entry.position.ToVector3();
        }
    }
}
