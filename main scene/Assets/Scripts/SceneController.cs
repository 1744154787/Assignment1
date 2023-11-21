using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // ��Ʒ�������飬���ڴ洢�����е���Ʒ
    public GameObject[] items;

    // ��ÿһ֡����ʱ����ⳡ���Ƿ������л�������ǣ��������Ʒ����ʾ״̬
    private void Update()
    {
        if (ChangjingManager.SceneChangeHappened) // ��������������л�
        {
            ChangjingManager.SceneChangeHappened = false; // ���ó����л���־
            UpdateItems(); // ������Ʒ����ʾ״̬
        }
    }

    // ������Ʒ����ʾ״̬�ķ���
    private void UpdateItems()
    {
        foreach (GameObject item in items) // ������Ʒ��������
        {
            // ��ȡ��Ʒ�����ͣ�����Ը��������Ҫ�޸���Ʒ������
            BackpackManager.ItemType type = item.name == "ItemA" ? BackpackManager.ItemType.ItemA : BackpackManager.ItemType.ItemB;
            // ��ȡ��Ʒ������
            int count = BackpackManager.Instance.items.Find(i => i.type == type).count;
            // �����Ʒ����������0��˵���Ѿ�ʰȡ���ˣ���������Ʒ����
            // �����Ʒ����������0��˵����û��ʰȡ��������ʾ��Ʒ����
            item.SetActive(count == 0);
        }
    }
}