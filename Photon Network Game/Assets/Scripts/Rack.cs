using Photon.Pun;
using Photon.Pun.Demo.SlotRacer.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    WALK,
    ATTACK,
    DIE,
    NONE
}

public class Rack : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] Animator animator;

    [SerializeField] GameObject destination;

    [SerializeField] NavMeshAgent navMeshAgent;


    // 컴포넌트 가져오는건 Awake에서 하기
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        state = State.WALK;
        destination = GameObject.Find("Projector Star");
    }

    
    void Update()
    {
    
        switch(state)
        {
            case State.WALK: Walk();
                break;

            case State.ATTACK: Attack(); 
                break;

            case State.DIE: Die(); 
                break;
            case State.NONE:
                break;
        }
    }

    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);

    }

    public void Attack()
    {
        animator.Play("Attack");
    }

    public void Die()
    {
        if (state != State.NONE)
        {
            state = State.DIE;

            navMeshAgent.speed = 0;

            animator.SetTrigger("Die");


            state = State.NONE; // 아무것도 아닌 상태
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projector Star"))
        {
            state = State.ATTACK;
        }
    }

    public void Release()
    {
        PhotonNetwork.Destroy(navMeshAgent.gameObject);
    }
}
