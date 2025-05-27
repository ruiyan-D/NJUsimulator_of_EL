using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    public Transform target;           // 要跟随的对象
    public Vector3 offset;             // 屏幕偏移量
    public Camera mainCamera;

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (target == null || mainCamera == null)
            return;

        // 将世界坐标转成屏幕坐标
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position + offset);

        // 将屏幕坐标转换为UI坐标
        rectTransform.position = screenPos;
    }
}
