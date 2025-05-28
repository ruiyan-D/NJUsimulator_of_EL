using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taskable : MonoBehaviour
{
    public Tasks[] task;

    [SerializeField]
    public int currentTask;

    public void DelegateTask()
    {
        if (task[currentTask].taskStatus == Tasks._taskStatus.notAccpted)
        {
            // 未委派任务时
            task[currentTask].taskStatus = Tasks._taskStatus.accepted;
            for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
            {
                if (PlayerStatus.instance.tasks[i].taskTitle.Equals(task[currentTask].taskTitle))
                {
                    PlayerStatus.instance.tasks[i].taskStatus = Tasks._taskStatus.accepted;
                    break;
                }
            }
            //Debug.Log("Task accepted");
        }
        else if (task[currentTask].taskStatus == Tasks._taskStatus.accepted)
        {
            // 任务进行中
            for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
            {
                if (PlayerStatus.instance.tasks[i].taskTitle.Equals(task[currentTask].taskTitle)
                    && PlayerStatus.instance.tasks[i].taskStatus == Tasks._taskStatus.finished)
                {
                    task[currentTask].taskStatus = Tasks._taskStatus.accepted;
                    // 这里要调用一次对话（？
                    break;
                }
            }
        }
        else if (task[currentTask].taskStatus == Tasks._taskStatus.finished)
        {
            // 任务已完成，前来结算（
        }
    }
}
