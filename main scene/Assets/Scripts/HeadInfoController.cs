using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HeadInfoController : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // ��ɫ�л������Ĵ���
    private int sceneChangeCount = 0;

    // ��ʾ���ֵ��ı����
    private Text numberText;

    // ��Awake�����л�ȡ�ı����������ʼ������Ϊ0
    private void Awake()
    {
        numberText = GetComponentInChildren<Text>();
        numberText.text = "0";
        playerAgent = GameObject.Find("player").GetComponent<NavMeshAgent>();

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
        if (playerAgent.velocity.magnitude > 0f) // �����ɫ���ٶȴ���0��˵����ɫ���ƶ�
        {
            numberText.text = "�ƶ�"; // �����ı����������Ϊ���ƶ���
        }
        else // ����˵����ɫ�ڴ���
        {
            numberText.text = "����"; // �����ı����������Ϊ��������
        }

    }
}
