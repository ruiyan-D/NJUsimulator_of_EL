using UnityEngine;


[System.Serializable]
public class Tasks
{
    public enum _taskStatus
    {
        notAccpted,
        accepted,
        finished
    };

    public string taskTitle;
    public string taskDescription;
    public _taskStatus taskStatus;

    public int _pointRewards;
}
