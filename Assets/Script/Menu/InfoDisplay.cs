using UnityEngine;
using UnityEngine.UI;

public class MenuInfoDisplay : MonoBehaviour
{
    public Text nameText;
    public Text idText;
    public Text scoreText;

    void Start()
    {
        if (PlayerStatus.instance != null)
        {
            nameText.text = "姓名：" + PlayerStatus.instance.playerName;
            idText.text = "学号：" + PlayerStatus.instance.studentId;
            scoreText.text = "分数：" + PlayerStatus.instance.Points.ToString();
        }
        else
        {
            nameText.text = "姓名：未知";
            idText.text = "学号：未知";
            scoreText.text = "分数：0";
        }
    }
}
