using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    // 目标场景的索引
    public int targetSceneIndex;

    // 射线方向和长度
    public Vector3 rayDirection = Vector3.up;
    public float rayLength = 5f;

    // 在每一帧更新时，从当前位置沿着射线方向发射一条射线
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
        {
            // 如果射线碰到了角色，调用游戏管理器的方法加载目标场景
            if (hit.collider.CompareTag("Player"))
            {
                ChangjingManager.Instance.LoadScene(targetSceneIndex);
                
            }
        }
    }
}