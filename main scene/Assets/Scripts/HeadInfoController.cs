using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HeadInfoController : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // 角色切换场景的次数
    private int sceneChangeCount = 0;

    // 显示数字的文本组件
    private Text numberText;

    // 在Awake方法中获取文本组件，并初始化数字为0
    private void Awake()
    {
        numberText = GetComponentInChildren<Text>();
        numberText.text = "0";
        playerAgent = GameObject.Find("player").GetComponent<NavMeshAgent>();

    }

    // 在Update方法中让Canvas始终朝向摄像机，并检测是否有场景切换的事件发生
    private void Update()
    {
        // 让Canvas朝向摄像机
        transform.forward = Camera.main.transform.forward;

        // 检测是否有场景切换的事件发生
        // 这里假设你有一个静态类SceneEventManager，用来管理场景切换的事件
        // 你可以根据自己的需求修改这部分代码
        if (ChangjingManager.SceneChangeHappened)
        {
            // 将次数加一，并更新文本
            sceneChangeCount++;
            numberText.text = sceneChangeCount.ToString();

            // 重置事件标志
            ChangjingManager.SceneChangeHappened = false;
        }
        if (playerAgent.velocity.magnitude > 0f) // 如果角色的速度大于0，说明角色在移动
        {
            numberText.text = "移动"; // 更新文本组件的内容为“移动”
        }
        else // 否则，说明角色在待机
        {
            numberText.text = "待机"; // 更新文本组件的内容为“待机”
        }

    }
}
