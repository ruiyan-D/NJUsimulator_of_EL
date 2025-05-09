using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [TextArea(1,4)]
    public string[] boxTextLines;
    public bool hasName;
    
    [SerializeField] private bool isEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
                BoxManager.instance.grabLines(boxTextLines, hasName);
            }
            else
            {
                Debug.LogError("BoxManager instance is missing!");
            }
        }
    }
}
