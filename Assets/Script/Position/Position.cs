using UnityEngine;

public class Position : MonoBehaviour
{
    public string positionID;
    public bool playerInRange { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PositionManager.Instance.SetPositionActive(positionID, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PositionManager.Instance.SetPositionActive(positionID, false);
        }
    }
}
