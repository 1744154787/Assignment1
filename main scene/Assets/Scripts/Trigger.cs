using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Ŀ���������ã������ڱ༭������ק��ֵ
    public GameObject target;
    public Vector3 rayDirection = Vector3.up;
    public float rayLength = 5f;

    private void Update()
    {
        // �ӵ�ǰλ���������߷�����һ������
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
        {
            // ����������������
            if (hit.collider.CompareTag("Player"))
            {
                // ��Ŀ�������һ����Ϊ Teleport ����Ϣ
                target.SendMessage("Teleport");
            }
        }
    }
}