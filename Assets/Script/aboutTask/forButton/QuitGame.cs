using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ItMeansIQuit()
    {
        //注：下面一行为调试专用的终止代码，正式游玩测试如果出了bug请删除
        // UnityEditor.EditorApplication.isPlaying=false;
        
        Application.Quit();
    }
}
