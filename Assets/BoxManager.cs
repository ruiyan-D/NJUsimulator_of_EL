using System.Collections;
using TMPro;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public static BoxManager instance;
    public GameObject boxSwitcher;
    public TextMeshProUGUI boxText, boxName;
    
    [TextArea(1,4)]
    public string[] boxTextLines;
    
    [SerializeField] private int currentLine;
    [SerializeField] private float textSpeed;
    
    private bool isScrolling = false;
    private bool forceComplete = false;         // 新增：强制完成标志
    private Coroutine currentTextCoroutine;     // 新增：跟踪当前协程

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (boxSwitcher.activeInHierarchy)
        {
            // 修改：检测按下事件（GetKeyDown 而非 GetKey）
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (isScrolling)
                {
                    // 如果正在滚动，立即完成当前行
                    forceComplete = true;
                }
                else
                {
                    // 正常切换到下一行
                    currentLine++;
                    if (currentLine < boxTextLines.Length)
                    {
                        getName();
                        currentTextCoroutine = StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        boxSwitcher.SetActive(false);
                        FindObjectOfType<MoveController>().moveable = true;
                    }
                }
            }
        }
    }

    public void grabLines(string[] lines, bool hasName)
    {
        boxTextLines = lines;
        currentLine = 0;
        boxSwitcher.SetActive(true);
        boxName.gameObject.SetActive(hasName);
        
        // 新增：停止之前的协程
        if (currentTextCoroutine != null)
        {
            StopCoroutine(currentTextCoroutine);
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

    // getName() 保持原样
    private void getName()
    {
        if (boxTextLines[currentLine].StartsWith("name:"))
        {
            boxName.text = boxTextLines[currentLine].Replace("name:", "");
            currentLine++;
        }
    }
}
