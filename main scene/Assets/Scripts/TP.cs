using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    // ��һ������������
    public string nextScene; // �����һ��

    // ���յ� Teleport ��Ϣʱ
    private void Teleport()
    {
        // ������һ������
        SceneManager.LoadScene(nextScene);
    }
}