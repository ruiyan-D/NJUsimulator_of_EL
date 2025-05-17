using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public string positionID;
    public GameObject noticeSignal;  // 拖拽绑定 NoticeSignal 物体
    public bool playerInRange { get; private set; }

    private Coroutine floatCoroutine;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        if (noticeSignal != null)
        {
            noticeSignal.SetActive(false);  // 默认隐藏
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PositionManager.Instance.SetPositionActive(positionID, true);
            if (noticeSignal != null)
            {
                noticeSignal.SetActive(true);
                if (floatCoroutine == null)
                {
                    floatCoroutine = StartCoroutine(FloatEffect());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PositionManager.Instance.SetPositionActive(positionID, false);

            // 隐藏 NoticeSignal
            if (noticeSignal != null)
            {
                noticeSignal.SetActive(false);
            }
        }
    }
    private IEnumerator FloatEffect()
    {
        Vector3 startPos = noticeSignal.transform.position;
        while (true)
        {
            float time = Mathf.PingPong(Time.time, 1f);
            noticeSignal.transform.position = startPos + Vector3.up * Mathf.Sin(time * Mathf.PI * 2) * 0.1f;
            yield return null;
        }
    }
}
