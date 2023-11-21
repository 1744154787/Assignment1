using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    // 单例模式，保证只有一个背包管理器实例
    public static BackpackManager Instance { get; private set; }

    // 物品类型枚举，用于区分不同的物品
    public enum ItemType
    {
        ItemA,
        ItemB
    }

    // 物品类，用于存储物品的信息
    public class Item
    {
        public ItemType type; // 物品类型
        public int count; // 物品数量
        public KeyCode key; // 物品对应的按键

        // 物品构造函数，传入物品类型和按键
        public Item(ItemType type, KeyCode key)
        {
            this.type = type;
            this.count = 0; // 初始数量为0
            this.key = key;
        }
    }

    // 物品列表，用于存储背包中的物品
    public List<Item> items;

    // 在游戏开始时，初始化背包管理器实例，并且不销毁它
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            items = new List<Item>(); // 初始化物品列表
            // 添加两个物品到物品列表中，分别为ItemA和ItemB，你可以根据你的需要修改物品类型和按键
            items.Add(new Item(ItemType.ItemA, KeyCode.Alpha1)); // 物品A对应按键1
            items.Add(new Item(ItemType.ItemB, KeyCode.Alpha2)); // 物品B对应按键2
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 在每一帧更新时，检测是否按下了物品对应的按键，如果是，则使用或丢弃物品
    private void Update()
    {
        foreach (Item item in items) // 遍历物品列表
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
    }

    // 使用物品的方法，传入物品对象
    private void UseItem(Item item)
    {
        item.count--; // 物品数量减一
        Debug.Log("You used one " + item.type + ". You have " + item.count + " left."); // 提示使用了一个物品，还剩多少个
        // 你可以在这里添加你想要的物品使用效果，比如增加生命值，触发事件等
    }

    // 拾取物品的方法，传入物品类型
    public void PickUpItem(ItemType type)
    {
        foreach (Item item in items) // 遍历物品列表
        {
            if (item.type == type) // 如果物品类型匹配
            {
                item.count++; // 物品数量加一
                Debug.Log("You picked up one " + item.type + ". You have " + item.count + " now."); // 提示拾取了一个物品，现在有多少个
                break; // 跳出循环
            }
        }
    }

    // 丢弃物品的方法，传入物品对象
    private void DropItem(Item item)
    {
        item.count = 0; // 物品数量清零
        Debug.Log("You dropped all your " + item.type + "."); // 提示丢弃了所有该物品
        // 你可以在这里添加你想要的物品丢弃效果，比如在场景中生成物品对象，触发事件等
    }
}