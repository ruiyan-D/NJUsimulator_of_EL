using UnityEngine;

public class AttachToCamera : MonoBehaviour
{
    public Vector3 offset = new Vector3(-8, 4, 2);
    private Transform camTransform;

    void LateUpdate()
    {
        // 每帧确保绑定的是当前激活的主摄像机
        if (Camera.main != null && Camera.main.transform != camTransform)
        {
            camTransform = Camera.main.transform;
            transform.SetParent(camTransform);
            transform.localPosition = offset;
            transform.localRotation = Quaternion.identity;
        }
    }
}
