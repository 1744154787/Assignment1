using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    // 一个静态变量，用来判断是否已经存在 BGM 游戏对象
    private static bool isCreated = false;

    // 初始化
    private void Awake()
    {
        // 设置 BGM 游戏对象为 DontDestroyOnLoad
        DontDestroyOnLoad(gameObject);

        // 如果已经存在 BGM 游戏对象
        if (isCreated)
        {
            // 销毁自身
            Destroy(gameObject);
        }
        else
        {
            // 否则，设置静态变量为 true
            isCreated = true;
        }
    }
}