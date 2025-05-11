using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        // 使整个组在场景切换时不被销毁
        DontDestroyOnLoad(gameObject);
    }
}
