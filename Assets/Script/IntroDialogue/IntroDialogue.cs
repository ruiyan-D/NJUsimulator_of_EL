using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogueManager : MonoBehaviour
{
    public Text systemText;
    public Text playerText;
    public GameObject systemBox;
    public GameObject playerBox;

    public Button optionButton1;
    public Button optionButton2;
    public Button optionButton3;

    public InputField nameInput;
    public Button submitNameButton;

    private int stage = 0;
    private bool awaitingInput = true;
    private bool waitingForChoice = false;

    private string playerName = "";
    private string studentId = "";

    void Start()
    {
        SetUIVisibility(false, false, false);
        playerBox.gameObject.SetActive(false);
        playerText.gameObject.SetActive(false);
        systemBox.gameObject.SetActive(true);
        systemText.gameObject.SetActive(true);
        systemText.text = "欢迎来到南京大学！";
    }

    void Update()
    {
        if (!InputBlocker.IsInputBlocked && Input.GetKeyDown(KeyCode.Space) && awaitingInput && !waitingForChoice)
        {
            stage++;
            HandleStage(stage);
        }
    }

    void HandleStage(int currentStage)
    {
        SetUIVisibility(false, false, false);
        //systemBox.gameObject.SetActive(true);
        //systemText.gameObject.SetActive(true);
        switch (currentStage)
        {
            case 1:
                systemBox.gameObject.SetActive(false);
                systemText.gameObject.SetActive(false);
                playerBox.gameObject.SetActive(true);
                playerText.gameObject.SetActive(true);
                playerText.text = "等等......我......这是哪里？我回到了大学吗？";
                break;
            case 2:
                playerBox.gameObject.SetActive(false);
                playerText.gameObject.SetActive(false);
                systemBox.gameObject.SetActive(true);
                systemText.gameObject.SetActive(true);
                systemText.text = "你重回十八岁，即将踏入南京大学的校园。";
                break;
            case 3:
                systemBox.gameObject.SetActive(false);
                systemText.gameObject.SetActive(false);
                playerBox.gameObject.SetActive(true);
                //playerText.gameObject.SetActive(true);
                ShowChoices("南京大学是什么样的大学呢？", "南京……哪的大学？");
                break;
            case 6:
                systemBox.gameObject.SetActive(false);
                systemText.gameObject.SetActive(false);
                playerBox.gameObject.SetActive(true);
                playerText.gameObject.SetActive(true);
                playerText.text = "听起来……好像很有故事的样子？我以前从没听说过。";
                break;
            case 7:
                playerBox.gameObject.SetActive(false);
                playerText.gameObject.SetActive(false);
                systemBox.gameObject.SetActive(true);
                systemText.gameObject.SetActive(true);
                systemText.text = "是啊，这里不仅有顶尖的学术氛围，还有很多属于南大学子的独家记忆：深夜的操场和自习室、可爱的猫咪、秋天的梧桐落叶……都等着你去探索。也许，你会在这里遇到一生难忘的故事。  ";
                break;
            case 8:
                systemBox.gameObject.SetActive(false);
                systemText.gameObject.SetActive(false);
                playerBox.gameObject.SetActive(true);
                playerText.gameObject.SetActive(true);
                playerText.text = "那么，你是谁呢？";
                break;
            case 9:
                playerBox.gameObject.SetActive(false);
                playerText.gameObject.SetActive(false);
                systemBox.gameObject.SetActive(true);
                systemText.gameObject.SetActive(true);
                systemText.text = "我是Beason——由四位“老学长”在公元 5202 年共同设计的虚拟引导系统，帮助你熟悉校园，快速适应大学生活。";
                break;
            case 10:
                playerBox.gameObject.SetActive(false);
                playerText.gameObject.SetActive(false);
                systemBox.gameObject.SetActive(true);
                systemText.gameObject.SetActive(true);
                systemText.text = "Beason：你还记得自己的名字吗？";
                ShowNameInput();
                break;
            case 11:
                playerBox.gameObject.SetActive(false);
                playerText.gameObject.SetActive(false);
                systemBox.gameObject.SetActive(true);
                systemText.gameObject.SetActive(true);
                systemText.text = $"Beason：很好，我找到你的学号了！：{studentId}\n（可在“MENU”(屏幕左上角点击按钮)中随时查看,菜单内还包括游戏帮助“HELP”，里面含有功能键介绍，请及时查看）\n\n现在，正式开始你的大学生活吧！第一步，带上行李，完成开学报到！";
                break;
            case 12:
                systemBox.gameObject.SetActive(false);
                systemText.gameObject.SetActive(false);
                playerBox.gameObject.SetActive(true);
                optionButton3.gameObject.SetActive(true);
                optionButton3.GetComponentInChildren<Text>().text = "开始游戏";
                optionButton3.onClick.RemoveAllListeners();
                optionButton3.onClick.AddListener(StartGame);
                break;
        }
    }

    void ShowChoices(string option1Text, string option2Text)
    {
        waitingForChoice = true;
        optionButton1.gameObject.SetActive(true);
        optionButton2.gameObject.SetActive(true);

        optionButton1.GetComponentInChildren<Text>().text = option1Text;
        optionButton2.GetComponentInChildren<Text>().text = option2Text;

        optionButton1.onClick.RemoveAllListeners();
        optionButton2.onClick.RemoveAllListeners();

        optionButton1.onClick.AddListener(() => SelectChoice("南京大学，简称南大，是一所既有“百年老干部”气质，又充满青春活力的神奇学校...\n南大始建于1902年，至今已有百余年历史，是无数学术大师的摇篮，也是创新思想的源泉，拥有雄厚的师资力量，丰富的学术资源，以及开放包容的校园文化。", 6));
        optionButton2.onClick.AddListener(() => SelectChoice("哈，南京大学，简称南大，可不是随便哪的大学哦...\n这里不仅是中国顶尖的学府，还被誉为“最美校园”之一，至今已有百余年历史了。", 6));
    }

    void SelectChoice(string systemDialogue, int nextStage)
    {
        playerBox.gameObject.SetActive(false);
        playerText.gameObject.SetActive(false);
        systemBox.gameObject.SetActive(true);
        systemText.gameObject.SetActive(true);
        systemText.text = systemDialogue;
        optionButton1.gameObject.SetActive(false);
        optionButton2.gameObject.SetActive(false);
        waitingForChoice = false;
        stage = nextStage - 1;  // 让 Update 推进到 nextStage
    }

    void ShowNameInput()
    {
        awaitingInput = false;
        nameInput.gameObject.SetActive(true);
        submitNameButton.gameObject.SetActive(true);

        submitNameButton.onClick.RemoveAllListeners();
        submitNameButton.onClick.AddListener(SubmitName);
    }

    void SubmitName()
    {
        playerName = nameInput.text;
        studentId = "25" + UnityEngine.Random.Range(10000, 99999).ToString();
        nameInput.gameObject.SetActive(false);
        submitNameButton.gameObject.SetActive(false);

        PlayerStatus.instance.playerName = playerName;
        PlayerStatus.instance.studentId = studentId;

        systemBox.gameObject.SetActive(false);
        systemText.gameObject.SetActive(false);
        playerBox.gameObject.SetActive(true);
        playerText.gameObject.SetActive(true);
        playerText.text = $"我叫 {playerName}。";

        awaitingInput = true;
        stage = 10;
    }

    void SetUIVisibility(bool buttonsVisible, bool inputVisible, bool submitVisible)
    {
        optionButton1.gameObject.SetActive(buttonsVisible);
        optionButton2.gameObject.SetActive(buttonsVisible);
        nameInput.gameObject.SetActive(inputVisible);
        submitNameButton.gameObject.SetActive(submitVisible);
    }

    void StartGame()
    {
        // 加载下一场景或进入游戏主界面
        UnityEngine.SceneManagement.SceneManager.LoadScene("South");
    }
}
