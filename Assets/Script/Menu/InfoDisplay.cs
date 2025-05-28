using UnityEngine;
using UnityEngine.UI;

public class MenuInfoDisplay : MonoBehaviour
{
    public Text nameText;
    public Text idText;

    void Start()
    {
        if (PlayerStatus.instance != null)
        {
            nameText.text = "姓名：" + PlayerStatus.instance.playerName;
            idText.text = "学号：" + PlayerStatus.instance.studentId;
        }
        else
        {
            nameText.text = "姓名：未知";
            idText.text = "学号：未知";
        }
    }
}
