using System.Collections.Generic;
using UnityEngine;

public class PositionManager : Singleton<PositionManager>
{
    private Dictionary<string, bool> activePositions = new Dictionary<string, bool>();

    public void SetPositionActive(string id, bool isActive)
    {
        if (activePositions.ContainsKey(id))
        {
            activePositions[id] = isActive;
        }
        else
        {
            activePositions.Add(id, isActive);
        }
    }

    public bool IsPositionActive(string id)
    {
        return activePositions.ContainsKey(id) && activePositions[id];
    }
}
