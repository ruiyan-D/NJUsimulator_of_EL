using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [TextArea(1,4)]
    public string[] boxTextLines;
    public bool hasName;
    
    [SerializeField] private bool isEntered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("isEntered!");
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Has get out!");
            isEntered = false;
        }
    }

    void Update()
    {
        if (isEntered && (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                      && BoxManager.instance.boxSwitcher.activeInHierarchy == false)
        {
            // 新增：空引用检查
            if (BoxManager.instance != null)
            {
                bool actualHasName = boxTextLines.Length > 0 && boxTextLines[0].StartsWith("name:");
                BoxManager.instance.grabLines(boxTextLines, actualHasName);
            }
            else
            {
                Debug.LogError("BoxManager instance is missing!");
            }
        }
    }
}
