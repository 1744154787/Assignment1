using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuYaoCuiHui : MonoBehaviour
{
    // 定义一个静态布尔变量，用来记录是否已经有一个角色被创建
    private static bool isCreated = false;

    private void Awake()
    {
        // 检查变量的值
        if (!isCreated)
        {
            // 如果为false，就说明这是第一个角色
            // 使用DontDestroyOnLoad函数，并把变量设为true
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            // 如果为true，就说明已经有一个角色存在了
            // 直接销毁这个角色
            Destroy(gameObject);
        }
    }
}
