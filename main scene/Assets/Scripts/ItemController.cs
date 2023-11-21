using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // 物品对象的预制体，用于在场景中生成物品对象
    public GameObject itemPrefab;

    // 角色对象，用于获取角色的位置和方向
    public GameObject player;

    // 当前正在使用的物品，初始为null
    private BackpackManager.Item currentItem = null;

    // 在每一帧更新时，检测是否有碰撞器进入了物品的触发区域，如果是，则判断是否是角色
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 如果是角色
        {
            // 获取物品的类型，你可以根据你的需要修改物品的类型
            BackpackManager.ItemType type = gameObject.name == "ItemA" ? BackpackManager.ItemType.ItemA : BackpackManager.ItemType.ItemB;
            // 调用背包管理器的方法拾取物品
            BackpackManager.Instance.PickUpItem(type);
            // 隐藏物品对象
            gameObject.SetActive(false);
        }
    }

    // 在每一帧更新时，检测是否按下了使用物品或丢弃物品的按键，如果是，则执行相应的操作
    private void Update()
    {
        foreach (BackpackManager.Item item in BackpackManager.Instance.items) // 遍历物品列表
        {
            if (Input.GetKeyDown(item.key)) // 如果按下了物品对应的按键
            {
                if (item.count > 0) // 如果物品数量大于0
                {
                    UseItem(item); // 使用物品
                }
                else // 如果物品数量等于0
                {
                    Debug.Log("You don't have any " + item.type + " in your backpack!"); // 提示没有该物品
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) // 如果按下了Q键
        {
            if (currentItem != null) // 如果当前正在使用某个物品
            {
                DropItem(currentItem); // 丢弃物品
            }
            else // 如果当前没有使用任何物品
            {
                Debug.Log("You are not using any item!"); // 提示没有使用任何物品
            }
        }
    }

    // 使用物品的方法，传入物品对象
    private void UseItem(BackpackManager.Item item)
    {
        if (currentItem != item) // 如果当前正在使用的物品不是该物品
        {
            currentItem = item; // 设置当前正在使用的物品为该物品
            Debug.Log("You are using " + item.type + ". Press Q to drop it."); // 提示正在使用该物品，按Q键丢弃
                                                                               // 你可以在这里添加你想要的物品使用效果，比如增加生命值，触发事件等
        }
    }

    // 丢弃物品的方法，传入物品对象
    private void DropItem(BackpackManager.Item item)
    {
        if (currentItem == item) // 如果当前正在使用的物品是该物品
        {
            item.count--; // 物品数量减一
            currentItem = null; // 设置当前正在使用的物品为null
            Debug.Log("You dropped one " + item.type + ". You have " + item.count + " left."); // 提示丢弃了一个物品，还剩多少个
                                                                                               // 在场景中角色前方生成一个物品对象
            Vector3 position = player.transform.position + player.transform.forward * 2f; // 计算物品对象的位置，你可以根据你的需要修改距离
            Quaternion rotation = Quaternion.identity; // 计算物品对象的旋转，你可以根据你的需要修改角度
            GameObject newItem = Instantiate(itemPrefab, position, rotation); // 生成物品对象
            newItem.name = item.type.ToString(); // 设置物品对象的名称
            newItem.AddComponent<ItemController>(); // 为物品对象添加物品控制器脚本
            newItem.GetComponent<ItemController>().itemPrefab = itemPrefab; // 为物品对象设置物品预制体
            newItem.GetComponent<ItemController>().player = player; // 为物品对象设置角色对象
        }
    }
}