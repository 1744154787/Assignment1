using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ��Start��������ӳ����л��¼��ļ�����
    private void Start()
    {
        // ��ӳ�����ʼ�����¼��ļ�����������OnSceneLoading����
        SceneManager.sceneLoaded += OnSceneLoading;

        // ��ӳ���ж������¼��ļ�����������OnSceneUnloaded����
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // ��OnSceneLoading�����м��ؽ�ɫ��λ�ã����ƶ���SpawnPoint��
    private void OnSceneLoading(Scene scene, LoadSceneMode mode)
    {
        // ���ؽ�ɫ��λ�ã�����ֵ��transform.position
        transform.position = PlayerPositionManager.Instance.LoadPosition();

        // ���ҵ�ǰ��������ΪSpawnPoint�����壬����ȡ��Transform���
        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;

        // ����ҵ���SpawnPoint���壬�ͽ���λ�ú���ת��ֵ��transform.position��transform.rotation
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            
        }
        
    }

    // ��OnSceneUnloaded�����б����ɫ��λ��
    private void OnSceneUnloaded(Scene scene)
    {
        // �����ɫ��λ�ã�����transform.position��Ϊ����
        PlayerPositionManager.Instance.SavePosition(transform.position);
    }
}




//��Ͷ���ˣ�������������