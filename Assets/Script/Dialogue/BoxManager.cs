using System.Collections;
using TMPro;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public static BoxManager instance;
    public GameObject DialogueBox;
    public TextMeshProUGUI boxText, boxName;
    
    [TextArea(1,4)]
    public string[] boxTextLines;
    
    [SerializeField] private int currentLine;
    [SerializeField] private float textSpeed;
    
    private bool isScrolling = false;
    private bool forceComplete = false;         // 强制完成标志
    private Coroutine currentTextCoroutine;     // 跟踪当前协程
    
    public Taskable taskable;                   // 管理任务委派
    
    public TaskTarget taskTarget;               // 管理任务状况

    public AudioSource audioSpeak;
    public AudioClip SpeakClip;

    //public PlayerStatus playerStat;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
            // 非根物体不用destroy保护
        }
        // 作为persistent对象已经实例化过一次了，无需再次检查，persistent大人会出手的
        // MARKER: 如果出现bug请检查这里
    }

    void Update()
    {
        updateContent();
    }
    private void updateContent()
    {
        if (DialogueBox.activeInHierarchy && boxTextLines.Length > 0)
        {
            // Debug.Log("Enter there.");
            // 修改：检测按下事件（GetKeyDown 而非 GetKey）
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Detected interact.");
                if (isScrolling)
                {
                    audioSpeak.Stop();
                    // 如果正在滚动，立即完成当前行
                    forceComplete = true;
                }
                else
                {
                    // 正常切换到下一行
                    currentLine++;
                    if (currentLine < boxTextLines.Length)
                    {
                        audioSpeak.Play();
                        getName();
                        currentTextCoroutine = StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        DialogueBox.SetActive(false);
                        FindObjectOfType<MoveController>().moveable = true;
                        
                        if (currentTextCoroutine != null)
                        {
                            StopCoroutine(currentTextCoroutine);
                            currentTextCoroutine = null;
                            isScrolling = false;
                            forceComplete = false;
                        }

                        if (taskable == null) // 存在不可发布任务的npc
                        { 
                            Debug.Log("This NPC cannot delegate task.");
                        }
                        else
                        {
                            taskable.DelegateTask();
                            TaskManager.instance.UpdateTaskList();
                        }

                        if (taskTarget != null)
                        {
                            taskTarget.hasTalked = true;
                            taskTarget.targetComplete();
                        }
                        else
                        {
                            Debug.Log("This NPC cannot help with task.");
                        }

                        boxTextLines = null;

                    }
                }
            }
        }
    }

    public void grabLines(string[] lines, bool hasName)
    {
        boxTextLines = lines;
        currentLine = 0;
        DialogueBox.SetActive(true);

        getName();

        boxName.gameObject.SetActive(hasName);
        
        if (currentTextCoroutine != null)
        {
            StopCoroutine(currentTextCoroutine);
            currentTextCoroutine = null;
            isScrolling = false;
            forceComplete = false;
        }

        currentTextCoroutine = StartCoroutine(ScrollingText());
        
        FindObjectOfType<MoveController>().moveable = false;
    }

    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        boxText.text = "";
        forceComplete = false;
        
        string fullText = boxTextLines[currentLine];
        for (int i = 0; i < fullText.Length; i++)  // 改用 for 循环
        {
            if (forceComplete)  // 检测强制完成标志
            {
                boxText.text = fullText;  // 直接填充全部文本
                break;
            }
            boxText.text += fullText[i];
            yield return new WaitForSeconds(textSpeed);
        }
        
        isScrolling = false;
    }
    
    private void getName()
    {
        if (boxTextLines[currentLine].StartsWith("name:"))
        {
            //Debug.Log("Has given name!");
            if (boxTextLines[currentLine].Equals("name:Player"))
            {
                boxName.text = PlayerStatus.instance.playerName;
                currentLine++;
            }
            else
            {
                boxName.text = boxTextLines[currentLine].Replace("name:", "");
                currentLine++;
            }
        }
    }
// DelegateTask
    public int checkQuestStatus()
    {
        // 逻辑：先判定玩家完成但是NPC处没有更新状态的，再判断processing的，再判定未接取的，其他不管
        // 0表示空，使用default对话；1表示未更新状态的，使用任务后对话；2表示processing，使用任务中对话；3表示接取任务对话
        // 其实还有个想法是任务后替换default对话，先修完bug再来搞
        if (taskable == null)
        {
            Debug.Log(taskable);
            return 0;
        }
        
        for (int j = 0; j < PlayerStatus.instance.tasks.Length; j++)
        {
            if (taskable.task[taskable.currentTask].taskTitle.Equals(PlayerStatus.instance.tasks[j].taskTitle))
            {
                if(PlayerStatus.instance.tasks[j].taskStatus == Tasks._taskStatus.finished
                   && taskable.task[taskable.currentTask].taskStatus == Tasks._taskStatus.accepted)
                    return 1;
                if (PlayerStatus.instance.tasks[j].taskStatus == Tasks._taskStatus.accepted)
                    return 2;
                if (PlayerStatus.instance.tasks[j].taskStatus == Tasks._taskStatus.notAccpted)
                    return 3;
            }
        }
        
        Debug.Log("404 not FOUND");
        return 0;
    }
}
