using UnityEngine;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    [Header("Dialogue before delegation")]
    [TextArea(1,4)]
    [SerializeField] protected string[] priorTexts;
    [Header("Dialogue during delegation")]
    [TextArea(1,4)]
    [SerializeField] protected string[] processingTexts;
    [Header("Dialogue after delegation")]
    [TextArea(1,4)]
    [SerializeField] protected string[] afterwardsTexts;
    [Header("Default Dialogue")]
    [TextArea(1,4)]
    [SerializeField] protected string[] defaultTexts;
    
    // 注：错误文本仅用于报错，正常情况不会出现
    [Header("Error Dialogue")]
    [TextArea(1,4)]
    [SerializeField] protected string[] errorTexts;
    
    
    [SerializeField] protected bool hasName;
    [SerializeField] private protected bool isEntered;
    
    public Taskable taskable;
    
    public TaskTarget taskTarget;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("isEntered!");
            isEntered = true;
            
            //Debug.Log("Taskable given!");
            BoxManager.instance.taskable = taskable;
            BoxManager.instance.taskTarget = taskTarget;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Has get out!");
            isEntered = false;
            
            //Debug.Log("Taskable cleared!");
            BoxManager.instance.taskable = null;
            BoxManager.instance.taskTarget = null;
        }
    }

    void Update()
    {
        interact();
    }

    void interact()
    {
        if (isEntered && (Input.GetKeyDown(KeyCode.F)) && BoxManager.instance.DialogueBox.activeInHierarchy == false)
        {
            string[] texts;
            int key = BoxManager.instance.checkQuestStatus();
            switch (key)
            {
                case 0:
                    // 无任务
                    Debug.Log("Given defaultTexts");
                    texts = defaultTexts;
                    break;
                case 1:
                    // 未更新
                    Debug.Log("Given afterwardsTexts");
                    texts = afterwardsTexts;
                    break;
                case 2:
                    // 进行中
                    Debug.Log("Given processingTexts");
                    texts = processingTexts;
                    break;
                case 3:
                    // 待接取
                    Debug.Log("Given priorTexts");
                    texts = priorTexts;
                    break;
                default:
                    Debug.Log("Given errorTexts");
                    texts = errorTexts;
                    break;
            }
            // 新增：空引用检查
            if (BoxManager.instance != null)
            {
                bool actualHasName = texts.Length > 0 && texts[0].StartsWith("name:");
                BoxManager.instance.grabLines(texts, actualHasName);
            }
            else
            {
                Debug.LogError("BoxManager instance is missing!");
            }
        }
    }
}
