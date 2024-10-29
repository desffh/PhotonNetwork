using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rack : MonoBehaviour
{
    [SerializeField] GameObject destination;

    [SerializeField] NavMeshAgent navMeshAgent;

    // 컴포넌트 가져오는건 Awake에서 하기
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
