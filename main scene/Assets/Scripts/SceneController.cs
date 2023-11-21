using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // 物品对象数组，用于存储场景中的物品
    public GameObject[] items;

    // 在每一帧更新时，检测场景是否发生了切换，如果是，则更新物品的显示状态
    private void Update()
    {
        if (ChangjingManager.SceneChangeHappened) // 如果场景发生了切换
        {
            ChangjingManager.SceneChangeHappened = false; // 重置场景切换标志
            UpdateItems(); // 更新物品的显示状态
        }
    }

    // 更新物品的显示状态的方法
    private void UpdateItems()
    {
        foreach (GameObject item in items) // 遍历物品对象数组
        {
            // 获取物品的类型，你可以根据你的需要修改物品的类型
            BackpackManager.ItemType type = item.name == "ItemA" ? BackpackManager.ItemType.ItemA : BackpackManager.ItemType.ItemB;
            // 获取物品的数量
            int count = BackpackManager.Instance.items.Find(i => i.type == type).count;
            // 如果物品的数量大于0，说明已经拾取过了，就隐藏物品对象
            // 如果物品的数量等于0，说明还没有拾取过，就显示物品对象
            item.SetActive(count == 0);
        }
    }
}