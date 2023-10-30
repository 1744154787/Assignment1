using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseClickMove : MonoBehaviour
{
    private NavMeshAgent PlayerAgent;
    private AudioSource audioSource;
    [SerializeField]// ��ƵԴ���
    private AudioClip[] footstepSounds; // ��Ƶ��������
    private float distanceCounter; // ���������
    public float footstepDistance = 1f; // ���ŽŲ����ľ�����

    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GameObject.Find("player").GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>(); // ��ȡ��ƵԴ���
        distanceCounter = 0f; // ��ʼ�����������
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenPos = Input.mousePosition;
        Vector3 TagPos;
        Ray ray = Camera.main.ScreenPointToRay(ScreenPos);
        RaycastHit hit;
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    float dis = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);
                    TagPos = hit.point;
                    if (dis > 0)
                    {
                        PlayerAgent.SetDestination(TagPos);
                        
                    }
                }
            }
        }
        distanceCounter += PlayerAgent.velocity.magnitude * Time.deltaTime; // �ۼ��ƶ��ľ���
        if (distanceCounter >= footstepDistance) // �������ﵽ���
        {
            AudioManager.Instance.RandomSFX(AudioManager.Instance.footstepSounds);
            distanceCounter = 0f; // ���þ��������
        }

    }

    void PlayFootstepSound()
    {
        int index = Random.Range(0, footstepSounds.Length); // ���ѡ��һ����Ƶ����
        AudioClip clip = footstepSounds[index]; // ��ȡ��Ƶ����
        audioSource.PlayOneShot(clip); // ������Ƶ����
    }
}
