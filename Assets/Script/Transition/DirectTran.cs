using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectTran : MonoBehaviour
{
    public string positionID;
    public string sceneFrom;
    public string sceneToGo;
    public void directTran(){
        TransitionManager.Instance.Transition(sceneFrom, sceneToGo);
    }
}
