using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDateController : MonoBehaviour
{
    // 单例实例
    public static NPCDateController Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // 日期变化时更新所有 NPC
    public void UpdateAllNPCs(int currentDate)
    {
        // 获取所有 NPC 日期组件（包括 inactive 的）
        NPCDateCondition[] allNPCs = FindObjectsOfType<NPCDateCondition>(true);
        
        foreach (NPCDateCondition npc in allNPCs)
        {
            npc.UpdateActivationState(currentDate);
        }
    }
}
