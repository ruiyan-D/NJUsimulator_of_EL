using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressC : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Teleport[] allTeleports = FindObjectsOfType<Teleport>();
            foreach (var tp in allTeleports)
            {
                if (tp.positionID!="MENU"&&PositionManager.Instance.IsPositionActive(tp.positionID))
                {
                    tp.TeleportToScene();
                    break;
                }
            }
        }
    }
}
