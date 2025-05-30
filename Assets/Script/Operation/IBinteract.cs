using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBinteract : MonoBehaviour
{
    [Header("展示牌上的信息")] 
    [TextArea(1,4)]
    public string[] infoLines;
    
    [SerializeField] private protected bool isEntered;

    [SerializeField] private protected bool hasVisited;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }

    private void Update()
    {
        if (isEntered && (Input.GetKeyDown(KeyCode.F)) && BoxManager.instance.DialogueBox.activeInHierarchy == false)
        {
            BoxManager.instance.audioSpeak.Play();
            if (!hasVisited)
            {
                PlayerStatus.instance.Points += 2;
                hasVisited = true;
            }
            if (BoxManager.instance != null)
            {
                bool actualHasName = infoLines.Length > 0 && infoLines[0].StartsWith("name:");
                BoxManager.instance.grabLines(infoLines, actualHasName);
            }
            else
            {
                Debug.LogError("BoxManager instance is missing!");
            }
        }
    }
}
