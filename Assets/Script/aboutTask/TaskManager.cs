using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    public GameObject TaskBox;
    public GameObject TaskPerfab;
    public List<GameObject> taskList;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
    }
    
    public RectTransform content; // 拖拽Content对象到此处
    public GameObject buttonPrefab; // 拖拽按钮预制体到此处
    
    public void UpdateTaskList()
    {
        // 检查 PlayerStatus 和 tasks 是否有效
        if (PlayerStatus.instance == null || PlayerStatus.instance.tasks == null)
        {
            Debug.LogError("PlayerStatus or tasks is null!");
            return;
        }

        // 清空旧任务
        foreach (var taskObj in taskList)
        {
            Destroy(taskObj);
        }
        taskList.Clear();

        // 添加新任务
        for (int i = 0; i < PlayerStatus.instance.tasks.Length; i++)
        {
            if(PlayerStatus.instance.tasks[i].taskStatus == Tasks._taskStatus.accepted)
                AddPerfab(PlayerStatus.instance.tasks[i], i);
        }
    }

    private void AddPerfab(Tasks task, int rank)
    {
        if (task == null)
        {
            Debug.LogError("Task is null!");
            return;
        }

        if (buttonPrefab == null || content == null)
        {
            Debug.LogError("buttonPrefab or content is not assigned!");
            return;
        }

        // 实例化预制体
        GameObject newPerfab = Instantiate(buttonPrefab, content);
        newPerfab.name = "" + rank;

        // 找到 Button -> TaskText 子对象
        Transform buttonTransform = newPerfab.transform.Find("Button");
        if (buttonTransform == null)
        {
            Debug.LogError("Button child not found!");
            return;
        }

        Transform taskTextTransform = buttonTransform.transform.Find("TaskText");
        if (taskTextTransform == null)
        {
            Debug.LogError("TaskText child not found!");
            return;
        }
        
        Transform taskDesTransform = buttonTransform.transform.Find("TaskDes");
        if (taskDesTransform == null)
        {
            Debug.LogError("TaskDes child not found!");
            return;
        }

        // 获取 TextMeshProUGUI 组件
        if (taskTextTransform.TryGetComponent<TextMeshProUGUI>(out var textComponent))
        {
            textComponent.text = task.taskTitle;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on TaskText!");
        }

        if (taskDesTransform.TryGetComponent<TextMeshProUGUI>(out var desTextComponent))
        {
            desTextComponent.text = task.taskDescription;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on TaskDes!");
        }

        taskList.Add(newPerfab);
    }
}
