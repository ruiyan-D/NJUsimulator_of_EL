using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunToNextDay : MonoBehaviour
{
    public void onClick()
    {
        int temp = PlayerStatus.instance.playingDate;
        temp = temp - temp % 100 + 100;
        PlayerStatus.instance.playingDate = temp;
    }

}
