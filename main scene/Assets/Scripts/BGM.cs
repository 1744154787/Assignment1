using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    // һ����̬�����������ж��Ƿ��Ѿ����� BGM ��Ϸ����
    private static bool isCreated = false;

    // ��ʼ��
    private void Awake()
    {
        // ���� BGM ��Ϸ����Ϊ DontDestroyOnLoad
        DontDestroyOnLoad(gameObject);

        // ����Ѿ����� BGM ��Ϸ����
        if (isCreated)
        {
            // ��������
            Destroy(gameObject);
        }
        else
        {
            // �������þ�̬����Ϊ true
            isCreated = true;
        }
    }
}