using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    // 点数
    public int Points;
    // 全任务列表，后续要更改接取和结束逻辑
    [SerializeField]
    public Tasks[] tasks =
    {
        new ("搬行李",10,Tasks._taskType.Reaching,"在热情学姐的指引下，踏上南大的第一步。沿着她指的方向，绕过南园8舍，穿过热闹的校园，到达南3宿舍。你的目标是顺利抵达宿舍，为大学生活的开始铺好第一块基石。 "),
        new ("新生报到",10,Tasks._taskType.Talking,"进入宿舍后，室友提醒你还未完成关键的一步——新生报到。赶紧前往宿舍楼前的红棚子，那里有志愿者等着你。完成登记后，你将领取南大的第一份“通行证”——校园卡！ "),
        new ("拍摄学生证照片",10,Tasks._taskType.Talking,"到达北园南教学楼（北园东侧最南面），进入教室拍照（鼠标点击相机）。分值10分。"),
        new ("整理宿舍",0,Tasks._taskType.Talking,"回到宿舍与室友交流，完成对话后上床休息。")
    };

    public string studentId;
    public string playerName;
    public int playingDate;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
