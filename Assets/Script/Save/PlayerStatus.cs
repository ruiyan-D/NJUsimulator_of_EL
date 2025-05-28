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
        new ("搬行李",10,Tasks._taskType.Reaching,"到达宿舍，任务完成。分值10分。"),
        new ("新生报到",10,Tasks._taskType.Talking,"到达宿舍楼前红棚子处与志愿者交流，报到领取校园卡。分值10分。"),
        new ("拍摄学生证照片",10,Tasks._taskType.Talking,"到达北园南教学楼（北园东侧最南面），进入教室拍照（鼠标点击相机）。分值10分。"),
        new ("整理宿舍",0,Tasks._taskType.Talking,"回到宿舍与室友交流，完成对话后上床休息。")
    };
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
