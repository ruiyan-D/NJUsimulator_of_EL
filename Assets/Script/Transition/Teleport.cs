using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string positionID;
    public string sceneFrom;
    public string sceneToGo;
    public void TeleportToScene(){
        if (!string.IsNullOrEmpty(sceneFrom) && !string.IsNullOrEmpty(sceneToGo))
            TransitionManager.Instance.Transition(sceneFrom,sceneToGo);
    }
}
