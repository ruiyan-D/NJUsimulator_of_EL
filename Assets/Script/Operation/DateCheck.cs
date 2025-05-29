using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    public int demonstrateDate;

    private void Update()
    {
        gameObject.SetActive(PlayerStatus.instance.playingDate >= demonstrateDate
        && PlayerStatus.instance.playingDate -1 <= demonstrateDate);
    }
}
