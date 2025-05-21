using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTaskPanel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && TaskManager.instance.TaskBox.activeInHierarchy == false)
        {
            if (TaskManager.instance != null)
            {
                TaskManager.instance.TaskBox.SetActive(true);
            }
            else
            {
                Debug.Log("TaskBox not found!");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && TaskManager.instance.TaskBox.activeInHierarchy == true)
        {
            if (TaskManager.instance != null)
            {
                TaskManager.instance.TaskBox.SetActive(false);
            }
            else
            {
                Debug.Log("TaskBox not found!");
            }
        }
    }
}
