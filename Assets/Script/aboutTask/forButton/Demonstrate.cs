using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Demonstrate : MonoBehaviour
{
    public GameObject chosenPanel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Button button;
    public void OnClick()
    {
        chosenPanel.SetActive(true);
        titleText.text = button.transform.Find("TaskText").GetComponent<TMP_Text>().text;
        descriptionText.text = button.transform.Find("TaskDes").GetComponent<TMP_Text>().text;
    }
}
