using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    // ����һ����̬��PlayerPositionManagerʵ��
    public static PlayerPositionManager Instance { get; private set; }

    // ����һ��Vector3�����������洢��ɫ��λ��
    private Vector3 playerPosition;

    // ��Awake�����г�ʼ��ʵ��������ֹ������
    private void Awake()
    {
        // ���ʵ��Ϊ�գ��ͽ���ǰ����ֵ������������Ϊ��������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���ʵ����Ϊ�գ���˵���Ѿ���һ����������ˣ������ٵ�ǰ����
            Destroy(gameObject);
        }
    }

    // ����һ��SavePosition���������������ɫ��λ��
    public void SavePosition(Vector3 position)
    {
        // ������Ĳ�����ֵ��playerPosition����
        playerPosition = position;
    }

    // ����һ��LoadPosition�������������ؽ�ɫ��λ��
    public Vector3 LoadPosition()
    {
        // ����playerPosition������ֵ
        return playerPosition;
    }
}