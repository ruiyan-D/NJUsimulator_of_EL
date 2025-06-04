using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabData : MonoBehaviour
{
    public TextMeshProUGUI pointReport;
    public TextMeshProUGUI taskReport;
    public TextMeshProUGUI level;
    public TextMeshProUGUI summary;

    public void OnClick()
    {
        summary.text = "  你回顾这半学期的大学生活，从最初的懵懂与拘谨，到如今逐渐适应节奏、勇敢面对各种挑战。你完成了课程学习、参与了任务探索，与同学们建立了联系，也在一次次的交流中找到了属于自己的节奏。期中考试的努力没有白费，期末考试你也顺利应对，虽然还有遗憾，但更多的是收获。你开始明白，大学不仅是学习的场所，更是成长与自我探索的舞台。恭喜你顺利度过适应期，欢迎进入真正的大学生活。";
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
            level.text = "等级：A！\n看上去有在好好玩我们制作的游戏呢（，希望你在真实的南大中过得愉快！";
        }
        else if (PlayerStatus.instance.Points < 130)
        {
            level.text = "等级：B！\n你似乎连主线任务都没做完，可以告诉我是怎么卡的bug吗？";
        }
        else if (PlayerStatus.instance.Points > 150)
        {
            level.text = "等级：S！\n所有的奖励分都拿了还顺带看了建筑介绍吗，天哪……谢谢你的喜欢！";
        }
        else
        {
            level.text = "其他等级对话开发中";
        }
    }
}
