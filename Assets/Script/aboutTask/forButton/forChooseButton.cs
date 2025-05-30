using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forChooseButton : MonoBehaviour
{
    public void OnClick()
    {
        PlayerStatus.instance.playingDate ++;
        NPCDateController.Instance.UpdateAllNPCs(PlayerStatus.instance.playingDate);
    }
}
