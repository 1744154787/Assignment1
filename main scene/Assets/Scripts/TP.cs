using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    // 下一个场景的名称
    public string nextScene; // 添加这一行

    // 接收到 Teleport 消息时
    private void Teleport()
    {
        // 加载下一个场景
        SceneManager.LoadScene(nextScene);
    }
}