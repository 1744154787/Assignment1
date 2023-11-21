using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // ��Ʒ�����Ԥ���壬�����ڳ�����������Ʒ����
    public GameObject itemPrefab;

    // ��ɫ�������ڻ�ȡ��ɫ��λ�úͷ���
    public GameObject player;

    // ��ǰ����ʹ�õ���Ʒ����ʼΪnull
    private BackpackManager.Item currentItem = null;

    // ��ÿһ֡����ʱ������Ƿ�����ײ����������Ʒ�Ĵ�����������ǣ����ж��Ƿ��ǽ�ɫ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ����ǽ�ɫ
        {
            // ��ȡ��Ʒ�����ͣ�����Ը��������Ҫ�޸���Ʒ������
            BackpackManager.ItemType type = gameObject.name == "ItemA" ? BackpackManager.ItemType.ItemA : BackpackManager.ItemType.ItemB;
            // ���ñ����������ķ���ʰȡ��Ʒ
            BackpackManager.Instance.PickUpItem(type);
            // ������Ʒ����
            gameObject.SetActive(false);
        }
    }

    // ��ÿһ֡����ʱ������Ƿ�����ʹ����Ʒ������Ʒ�İ���������ǣ���ִ����Ӧ�Ĳ���
    private void Update()
    {
        foreach (BackpackManager.Item item in BackpackManager.Instance.items) // ������Ʒ�б�
        {
            if (Input.GetKeyDown(item.key)) // �����������Ʒ��Ӧ�İ���
            {
                if (item.count > 0) // �����Ʒ��������0
                {
                    UseItem(item); // ʹ����Ʒ
                }
                else // �����Ʒ��������0
                {
                    Debug.Log("You don't have any " + item.type + " in your backpack!"); // ��ʾû�и���Ʒ
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) // ���������Q��
        {
            if (currentItem != null) // �����ǰ����ʹ��ĳ����Ʒ
            {
                DropItem(currentItem); // ������Ʒ
            }
            else // �����ǰû��ʹ���κ���Ʒ
            {
                Debug.Log("You are not using any item!"); // ��ʾû��ʹ���κ���Ʒ
            }
        }
    }

    // ʹ����Ʒ�ķ�����������Ʒ����
    private void UseItem(BackpackManager.Item item)
    {
        if (currentItem != item) // �����ǰ����ʹ�õ���Ʒ���Ǹ���Ʒ
        {
            currentItem = item; // ���õ�ǰ����ʹ�õ���ƷΪ����Ʒ
            Debug.Log("You are using " + item.type + ". Press Q to drop it."); // ��ʾ����ʹ�ø���Ʒ����Q������
                                                                               // ������������������Ҫ����Ʒʹ��Ч����������������ֵ�������¼���
        }
    }

    // ������Ʒ�ķ�����������Ʒ����
    private void DropItem(BackpackManager.Item item)
    {
        if (currentItem == item) // �����ǰ����ʹ�õ���Ʒ�Ǹ���Ʒ
        {
            item.count--; // ��Ʒ������һ
            currentItem = null; // ���õ�ǰ����ʹ�õ���ƷΪnull
            Debug.Log("You dropped one " + item.type + ". You have " + item.count + " left."); // ��ʾ������һ����Ʒ����ʣ���ٸ�
                                                                                               // �ڳ����н�ɫǰ������һ����Ʒ����
            Vector3 position = player.transform.position + player.transform.forward * 2f; // ������Ʒ�����λ�ã�����Ը��������Ҫ�޸ľ���
            Quaternion rotation = Quaternion.identity; // ������Ʒ�������ת������Ը��������Ҫ�޸ĽǶ�
            GameObject newItem = Instantiate(itemPrefab, position, rotation); // ������Ʒ����
            newItem.name = item.type.ToString(); // ������Ʒ���������
            newItem.AddComponent<ItemController>(); // Ϊ��Ʒ���������Ʒ�������ű�
            newItem.GetComponent<ItemController>().itemPrefab = itemPrefab; // Ϊ��Ʒ����������ƷԤ����
            newItem.GetComponent<ItemController>().player = player; // Ϊ��Ʒ�������ý�ɫ����
        }
    }
}