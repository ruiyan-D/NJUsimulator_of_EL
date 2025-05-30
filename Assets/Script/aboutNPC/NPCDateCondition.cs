using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DateRange
{
    public int startDate; // 开始日期
    public int endDate;   // 结束日期
    
    // 检查日期是否在范围内
    public bool IsDateInRange(int date)
    {
        return date >= startDate && date <= endDate;
    }
}

// NPC 日期条件脚本（附加到每个 NPC）
public class NPCDateCondition : MonoBehaviour
{
    [Header("日期范围设置")]
    public DateRange activeDateRange = new DateRange();
    
    [Header("调试信息")]
    [SerializeField] private bool isActiveByDate = false;
    
    private void Start()
    {
        // 初始状态更新
        UpdateActivationState(PlayerStatus.instance.playingDate);
    }
    
    // 更新激活状态
    public void UpdateActivationState(int currentDate)
    {
        // 检查日期是否在范围内
        bool shouldBeActive = activeDateRange.IsDateInRange(currentDate);
        isActiveByDate = shouldBeActive;
        
        // 只有当状态实际变化时才更新
        if (gameObject.activeSelf != shouldBeActive)
        {
            gameObject.SetActive(shouldBeActive);
        }
        
        // 调试信息
        // Debug.Log($"NPC: {name} | Date: {currentDate} | Active: {shouldBeActive} | Range: {activeDateRange.startDate}-{activeDateRange.endDate}");
    }
}
