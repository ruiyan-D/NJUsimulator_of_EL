using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance; // 单例实例
    
    public AudioClip[] bgmTracks;
    private AudioSource audioSource;
    
    void Awake()
    {
        // 实现单例模式
        if (Instance == null)
        {
            Instance = this;
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
        }
    }
    
    // 播放指定BGM
    public void PlayBGM(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < bgmTracks.Length)
        {
            audioSource.clip = bgmTracks[trackIndex];
            audioSource.Play();
        }
    }
    
    // 停止BGM
    public void StopBGM()
    {
        audioSource.Stop();
    }
}
