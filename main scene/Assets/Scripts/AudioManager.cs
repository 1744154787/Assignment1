using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    // ����ģʽ����ֻ֤��һ��AudioManagerʵ��
    public static AudioManager Instance { get; private set; }

    // ��ƵԴ���
    public AudioSource bgmSource; // ��������Դ
    public AudioSource sfxSource; // ��ЧԴ

    // ��Ƶ��������
    public AudioClip[] bgmClips; // �������ּ���
    public AudioClip[] footstepSounds; // �Ų�������

    // ������ߵ�����Χ
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    // ����Ϸ��ʼʱ����ʼ��AudioManagerʵ�������Ҳ�������
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

    // ����һ����������Ч����
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    // ����һ���������Ч���������������������
    public void RandomSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        sfxSource.pitch = randomPitch;
        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();
    }

    // ����һ���������ּ���������Ѿ��ڲ��ţ����ظ�����
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip != clip)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }
}