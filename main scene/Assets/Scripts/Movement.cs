using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseClickMove : MonoBehaviour
{
    private NavMeshAgent PlayerAgent;
    private AudioSource audioSource;
    [SerializeField]// 音频源组件
    private AudioClip[] footstepSounds; // 音频剪辑数组
    private float distanceCounter; // 距离计数器
    public float footstepDistance = 1f; // 播放脚步声的距离间隔

    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GameObject.Find("player").GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>(); // 获取音频源组件
        distanceCounter = 0f; // 初始化距离计数器
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
        distanceCounter += PlayerAgent.velocity.magnitude * Time.deltaTime; // 累加移动的距离
        if (distanceCounter >= footstepDistance) // 如果距离达到间隔
        {
            AudioManager.Instance.RandomSFX(AudioManager.Instance.footstepSounds);
            distanceCounter = 0f; // 重置距离计数器
        }

    }

    void PlayFootstepSound()
    {
        int index = Random.Range(0, footstepSounds.Length); // 随机选择一个音频剪辑
        AudioClip clip = footstepSounds[index]; // 获取音频剪辑
        audioSource.PlayOneShot(clip); // 播放音频剪辑
    }
}
