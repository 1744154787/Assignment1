using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseClickMove : MonoBehaviour
{
    private NavMeshAgent PlayerAgent;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GameObject.Find("player").GetComponent<NavMeshAgent>();
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

    }
}
