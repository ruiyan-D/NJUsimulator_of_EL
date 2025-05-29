using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    public GameObject courseWindow;  // 拖入选课UI的Canvas Panel

    private bool playerNearby = false;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // 按 E 键打开/关闭选课界面
            courseWindow.SetActive(!courseWindow.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
