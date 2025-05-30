using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{
    public void OnClick()
    {
        PlayerStatus.instance.Points += 20;
        for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
        {
            if (PlayerStatus.instance.tasks[i].taskTitle.Equals("期末考"))
            {
                PlayerStatus.instance.tasks[i].taskStatus = Tasks._taskStatus.finished;
                PlayerStatus.instance.playingDate++;
                NPCDateController.Instance.UpdateAllNPCs(PlayerStatus.instance.playingDate);
                TaskManager.instance.UpdateTaskList();
                break;
            }
        }
    }
}
