using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTarget : MonoBehaviour
{
    public string targetName;
    public enum _targetStatus
    {
        notAccpted,
        accepted,
        finished
    };
    public _targetStatus status;

    public enum _targetType
    {
        Gathering,
        Talking,
        Reaching
    };
    public _targetType targetType;
    
    [Header("Gathering")] public int amount = 1;

    [Header("Talking")] public bool hasTalked;
    
    [Header("Reaching")] public bool hasReached;

    [Header("Points")] public int pointRewards;

    public void targetComplete()
    {
        for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
        {
            if (targetName.Equals(PlayerStatus.instance.tasks[i].taskTitle)
                && PlayerStatus.instance.tasks[i].taskStatus.Equals(Tasks._taskStatus.accepted))
            {
                switch (targetType)
                {
                    case _targetType.Gathering:
                        break;
                    case _targetType.Talking:
                        if (hasTalked)
                        {
                            PlayerStatus.instance.tasks[i].taskStatus = Tasks._taskStatus.finished;
                            PlayerStatus.instance.Points += pointRewards;
                            if(PlayerStatus.instance.tasks[i].taskKind.Equals(Tasks._taskKind.Main))
                                PlayerStatus.instance.playingDate++;
                            NPCDateController.Instance.UpdateAllNPCs(PlayerStatus.instance.playingDate);
                            TaskManager.instance.UpdateTaskList();
                        }
                        break;
                    case _targetType.Reaching:
                        if (hasReached)
                        {
                            PlayerStatus.instance.tasks[i].taskStatus = Tasks._taskStatus.finished;
                            PlayerStatus.instance.Points += pointRewards;
                            if(PlayerStatus.instance.tasks[i].taskKind.Equals(Tasks._taskKind.Main))
                                PlayerStatus.instance.playingDate++;
                            NPCDateController.Instance.UpdateAllNPCs(PlayerStatus.instance.playingDate);
                            TaskManager.instance.UpdateTaskList();
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (targetType.Equals(_targetType.Gathering))
            {
                amount++;
            }
            else if (targetType.Equals(_targetType.Reaching))
            {
                hasReached = true;
                targetComplete();
            }
        }
    }
}
