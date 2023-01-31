using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxePullOut : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    private void ChasePlayer()
    {
     GetComponent<Animator>().Play("EnemyAxePullOut");
    }
}
