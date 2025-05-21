using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taskable : MonoBehaviour
{
    public Tasks[] task;

    [SerializeField]
    private int currentTask;

    public void DelegateTask()
    {
        if (task[currentTask].taskStatus == Tasks._taskStatus.notAccpted)
        {
            // 未委派任务时
            task[currentTask].taskStatus = Tasks._taskStatus.accepted;
            PlayerStatus.instance.tasks.Add(task[currentTask]);
            //Debug.Log("Task accepted");
        }
        else if (task[currentTask].taskStatus == Tasks._taskStatus.accepted)
        {
            // 任务进行中
        }
        else if (task[currentTask].taskStatus == Tasks._taskStatus.finished)
        {
            // 任务已完成
            task[currentTask].taskStatus = Tasks._taskStatus.finished;
            PlayerStatus.instance.tasks.Remove(task[currentTask]);
            currentTask++;
        }
    }
}
