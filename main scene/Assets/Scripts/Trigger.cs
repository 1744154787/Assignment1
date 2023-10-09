using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // 目标对象的引用，可以在编辑器中拖拽赋值
    public GameObject target;
    public Vector3 rayDirection = Vector3.up;
    public float rayLength = 5f;

    private void Update()
    {
        // 从当前位置沿着射线方向发射一条射线
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
        {
            // 如果射线碰到了玩家
            if (hit.collider.CompareTag("Player"))
            {
                // 向目标对象发送一个名为 Teleport 的消息
                target.SendMessage("Teleport");
            }
        }
    }
}