using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    // 单例模式，保证只有一个AudioManager实例
    public static AudioManager Instance { get; private set; }

    // 音频源组件
    public AudioSource bgmSource; // 背景音乐源
    public AudioSource sfxSource; // 音效源

    // 音频剪辑数组
    public AudioClip[] bgmClips; // 背景音乐剪辑
    public AudioClip[] footstepSounds; // 脚步声剪辑

    // 随机音高调整范围
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    // 在游戏开始时，初始化AudioManager实例，并且不销毁它
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 播放一个单独的音效剪辑
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    // 播放一个随机的音效剪辑，并且随机调整音高
    public void RandomSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        sfxSource.pitch = randomPitch;
        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();
    }

    // 播放一个背景音乐剪辑，如果已经在播放，则不重复播放
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip != clip)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }
}