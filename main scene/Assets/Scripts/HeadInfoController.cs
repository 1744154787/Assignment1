using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadInfoController : MonoBehaviour
{
    // ��ɫ�л������Ĵ���
    private int sceneChangeCount = 0;

    // ��ʾ���ֵ��ı����
    private Text numberText;

    // ��Awake�����л�ȡ�ı����������ʼ������Ϊ0
    private void Awake()
    {
        numberText = GetComponentInChildren<Text>();
        numberText.text = "0";
    }

    // ��Update��������Canvasʼ�ճ����������������Ƿ��г����л����¼�����
    private void Update()
    {
        // ��Canvas���������
        transform.forward = Camera.main.transform.forward;

        // ����Ƿ��г����л����¼�����
        // �����������һ����̬��SceneEventManager�������������л����¼�
        // ����Ը����Լ��������޸��ⲿ�ִ���
        if (ChangjingManager.SceneChangeHappened)
        {
            // ��������һ���������ı�
            sceneChangeCount++;
            numberText.text = sceneChangeCount.ToString();

            // �����¼���־
            ChangjingManager.SceneChangeHappened = false;
        }
    }
}
