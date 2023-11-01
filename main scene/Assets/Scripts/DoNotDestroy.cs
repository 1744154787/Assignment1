using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuYaoCuiHui : MonoBehaviour
{
    // ����һ����̬����������������¼�Ƿ��Ѿ���һ����ɫ������
    private static bool isCreated = false;

    private void Awake()
    {
        // ��������ֵ
        if (!isCreated)
        {
            // ���Ϊfalse����˵�����ǵ�һ����ɫ
            // ʹ��DontDestroyOnLoad���������ѱ�����Ϊtrue
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            // ���Ϊtrue����˵���Ѿ���һ����ɫ������
            // ֱ�����������ɫ
            Destroy(gameObject);
        }
    }
}
