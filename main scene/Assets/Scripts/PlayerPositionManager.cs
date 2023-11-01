using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    // 定义一个静态的PlayerPositionManager实例
    public static PlayerPositionManager Instance { get; private set; }

    // 定义一个Vector3变量，用来存储角色的位置
    private Vector3 playerPosition;

    // 在Awake方法中初始化实例，并防止被销毁
    private void Awake()
    {
        // 如果实例为空，就将当前对象赋值给它，并设置为不被销毁
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果实例不为空，就说明已经有一个对象存在了，就销毁当前对象
            Destroy(gameObject);
        }
    }

    // 定义一个SavePosition方法，用来保存角色的位置
    public void SavePosition(Vector3 position)
    {
        // 将传入的参数赋值给playerPosition变量
        playerPosition = position;
    }

    // 定义一个LoadPosition方法，用来加载角色的位置
    public Vector3 LoadPosition()
    {
        // 返回playerPosition变量的值
        return playerPosition;
    }
}