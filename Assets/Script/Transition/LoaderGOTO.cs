using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LoaderGOTO : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "SeapeanSaveFile.json");
    }

    void Start()
    {
        if (File.Exists(filePath))
        {
            SceneManager.LoadScene("Scenes/Menu");
        }
        else
        {
            SceneManager.LoadScene("Scenes/IntroScene");
        }
    }
}
