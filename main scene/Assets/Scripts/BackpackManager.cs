using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    // ����ģʽ����ֻ֤��һ������������ʵ��
    public static BackpackManager Instance { get; private set; }

    // ��Ʒ����ö�٣��������ֲ�ͬ����Ʒ
    public enum ItemType
    {
        ItemA,
        ItemB
    }

    // ��Ʒ�࣬���ڴ洢��Ʒ����Ϣ
    public class Item
    {
        public ItemType type; // ��Ʒ����
        public int count; // ��Ʒ����
        public KeyCode key; // ��Ʒ��Ӧ�İ���

        // ��Ʒ���캯����������Ʒ���ͺͰ���
        public Item(ItemType type, KeyCode key)
        {
            this.type = type;
            this.count = 0; // ��ʼ����Ϊ0
            this.key = key;
        }
    }

    // ��Ʒ�б����ڴ洢�����е���Ʒ
    public List<Item> items;

    // ����Ϸ��ʼʱ����ʼ������������ʵ�������Ҳ�������
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            items = new List<Item>(); // ��ʼ����Ʒ�б�
            // ���������Ʒ����Ʒ�б��У��ֱ�ΪItemA��ItemB������Ը��������Ҫ�޸���Ʒ���ͺͰ���
            items.Add(new Item(ItemType.ItemA, KeyCode.Alpha1)); // ��ƷA��Ӧ����1
            items.Add(new Item(ItemType.ItemB, KeyCode.Alpha2)); // ��ƷB��Ӧ����2
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ��ÿһ֡����ʱ������Ƿ�������Ʒ��Ӧ�İ���������ǣ���ʹ�û�����Ʒ
    private void Update()
    {
        foreach (Item item in items) // ������Ʒ�б�
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
    }

    // ʹ����Ʒ�ķ�����������Ʒ����
    private void UseItem(Item item)
    {
        item.count--; // ��Ʒ������һ
        Debug.Log("You used one " + item.type + ". You have " + item.count + " left."); // ��ʾʹ����һ����Ʒ����ʣ���ٸ�
        // ������������������Ҫ����Ʒʹ��Ч����������������ֵ�������¼���
    }

    // ʰȡ��Ʒ�ķ�����������Ʒ����
    public void PickUpItem(ItemType type)
    {
        foreach (Item item in items) // ������Ʒ�б�
        {
            if (item.type == type) // �����Ʒ����ƥ��
            {
                item.count++; // ��Ʒ������һ
                Debug.Log("You picked up one " + item.type + ". You have " + item.count + " now."); // ��ʾʰȡ��һ����Ʒ�������ж��ٸ�
                break; // ����ѭ��
            }
        }
    }

    // ������Ʒ�ķ�����������Ʒ����
    private void DropItem(Item item)
    {
        item.count = 0; // ��Ʒ��������
        Debug.Log("You dropped all your " + item.type + "."); // ��ʾ���������и���Ʒ
        // ������������������Ҫ����Ʒ����Ч���������ڳ�����������Ʒ���󣬴����¼���
    }
}