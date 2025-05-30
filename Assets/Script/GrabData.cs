using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabData : MonoBehaviour
{
    public TextMeshProUGUI pointReport;
    public TextMeshProUGUI taskReport;
    public TextMeshProUGUI level;

    public void OnClick()
    {
        pointReport.text = "你在本次探索中，获得了" + PlayerStatus.instance.Points + "点！";
        int sum = 0;
        for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
        {
            if (PlayerStatus.instance.tasks[i].taskStatus == Tasks._taskStatus.finished)
                sum++;
        }
        taskReport.text = "你在本次探索中，完成了" + sum + "个任务！";
        if (PlayerStatus.instance.Points >= 130 && PlayerStatus.instance.Points <= 150)
        {
            level.text = "你的评分是，A！看上去有在好好玩我们制作的游戏呢（，希望你在真实的南大中过得愉快！";
        }
        else if (PlayerStatus.instance.Points < 130)
        {
            level.text = "你的评分是，B！你似乎连主线任务都没做完，可以告诉我是怎么卡的bug吗？";
        }
        else if (PlayerStatus.instance.Points > 150)
        {
            level.text = "你的评分是，S！所有的奖励分都拿了还顺带看了建筑介绍吗，天哪……谢谢你的喜欢！";
        }
        else
        {
            level.text = "其他等级对话开发中";
        }
    }
}
