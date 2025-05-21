// TaskListScroller.cs
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelScroller : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 3f;

    private void Update()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0)
        {
            float newPos = scrollRect.verticalNormalizedPosition + scrollDelta * scrollSpeed;
            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(newPos);
        }
    }
}
