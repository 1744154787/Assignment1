using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 在Start方法中添加场景切换事件的监听器
    private void Start()
    {
        // 添加场景开始加载事件的监听器，调用OnSceneLoading方法
        SceneManager.sceneLoaded += OnSceneLoading;

        // 添加场景卸载完成事件的监听器，调用OnSceneUnloaded方法
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // 在OnSceneLoading方法中加载角色的位置，并移动到SpawnPoint处
    private void OnSceneLoading(Scene scene, LoadSceneMode mode)
    {
        // 加载角色的位置，并赋值给transform.position
        transform.position = PlayerPositionManager.Instance.LoadPosition();

        // 查找当前场景中名为SpawnPoint的物体，并获取其Transform组件
        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;

        // 如果找到了SpawnPoint物体，就将其位置和旋转赋值给transform.position和transform.rotation
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            
        }
        
    }

    // 在OnSceneUnloaded方法中保存角色的位置
    private void OnSceneUnloaded(Scene scene)
    {
        // 保存角色的位置，传入transform.position作为参数
        PlayerPositionManager.Instance.SavePosition(transform.position);
    }
}




//我投降了！我做不出来！