using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    public int demonstrateDate;

    void datecheck()
    {
        gameObject.SetActive(PlayerStatus.instance.playingDate == demonstrateDate);
    }
}
