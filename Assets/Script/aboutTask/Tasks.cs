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

    public enum _taskKind
    {
        Main,
        Side
    };

    public string taskTitle;
    [TextArea(1,4)]
    public string taskDescription;
    public _taskStatus taskStatus;
    public _taskType taskType;
    public int _pointRewards;
    public _taskKind taskKind;

    public Tasks(string name, int rewards, _taskType type, string des)
    {
        taskTitle = name;
        _pointRewards = rewards;
        taskType = type;
        taskDescription = des;
        taskStatus = _taskStatus.notAccpted;
    }
}
