using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rack : MonoBehaviour
{
    [SerializeField] GameObject destination;

    [SerializeField] NavMeshAgent navMeshAgent;

    // ������Ʈ �������°� Awake���� �ϱ�
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

        destination = GameObject.Find("Projector Star");
    }

    
    void Update()
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }
}
