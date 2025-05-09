using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItMeansIQuit()
    {
        //注：下面一行为调试专用的终止代码，正式游玩测试如果出了bug请删除
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    }
}
