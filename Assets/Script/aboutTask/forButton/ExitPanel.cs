using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public GameObject chosenPanel;
    public void OnClick()
    {
        chosenPanel.SetActive(false);
    }
}
