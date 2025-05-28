using UnityEngine;


[System.Serializable]
public class Tasks
{
    public enum _taskStatus
    {
        notAccpted,
        accepted,
        finished,
        // settled
    };

    public enum _taskType
    {
        Gathering,
        Talking,
        Reaching
    };

    public string taskTitle;
    public string taskDescription;
    public _taskStatus taskStatus;
    public _taskType taskType;
    public int _pointRewards;

    public Tasks(string name, int rewards, _taskType type, string des)
    {
        taskTitle = name;
        _pointRewards = rewards;
        taskType = type;
        taskDescription = des;
        taskStatus = _taskStatus.notAccpted;
    }
}
