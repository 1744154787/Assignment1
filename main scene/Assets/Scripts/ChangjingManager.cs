using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangjingManager : MonoBehaviour

{
    // 单例模式，保证只有一个游戏管理器实例
    public static ChangjingManager Instance { get; private set; }

    // 场景数组，用于存储所有的场景名称
    public string[] scenes;

    // 在游戏开始时，初始化游戏管理器实例，并且不销毁它
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

    // 根据索引加载对应的场景
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