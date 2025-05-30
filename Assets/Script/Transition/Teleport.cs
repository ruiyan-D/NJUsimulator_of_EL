using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string positionID;
    public string sceneFrom;
    public string sceneToGo;

    public void TeleportToScene()
    {
        if (!string.IsNullOrEmpty(sceneFrom) && !string.IsNullOrEmpty(sceneToGo))
        {
            // 修正：调用 SavePlayerPosition 时只传两个参数
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PositionManager.Instance.SavePlayerPosition(sceneFrom, player.transform.position);
            }

            TransitionManager.Instance.Transition(sceneFrom, sceneToGo);
            if (PlayerStatus.instance != null && TaskManager.instance != null)
            {
                TaskManager.instance.UpdateTaskList();
            }
        }
    }
}
