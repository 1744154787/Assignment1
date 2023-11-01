using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    // Ŀ�곡��������
    public int targetSceneIndex;

    // ���߷���ͳ���
    public Vector3 rayDirection = Vector3.up;
    public float rayLength = 5f;

    // ��ÿһ֡����ʱ���ӵ�ǰλ���������߷�����һ������
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
        {
            // ������������˽�ɫ��������Ϸ�������ķ�������Ŀ�곡��
            if (hit.collider.CompareTag("Player"))
            {
                ChangjingManager.Instance.LoadScene(targetSceneIndex);
                
            }
        }
    }
}