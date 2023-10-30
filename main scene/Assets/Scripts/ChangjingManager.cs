using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangjingManager : MonoBehaviour

{
    // ����ģʽ����ֻ֤��һ����Ϸ������ʵ��
    public static ChangjingManager Instance { get; private set; }

    // �������飬���ڴ洢���еĳ�������
    public string[] scenes;

    // ����Ϸ��ʼʱ����ʼ����Ϸ������ʵ�������Ҳ�������
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

    // �����������ض�Ӧ�ĳ���
    public void LoadScene(int index)
    {
        if (index >= 0 && index < scenes.Length)
        {
            SceneManager.LoadScene(scenes[index]);
        }
        else
        {
            Debug.LogError("Invalid scene index!");
        }
    }
}