using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToNextDay : MonoBehaviour
{
    public void getToNextDay()
    {
        int currentDate = PlayerStatus.instance.playingDate;
        currentDate = currentDate - currentDate % 100 + 100;
        PlayerStatus.instance.playingDate = currentDate;
    }
}
