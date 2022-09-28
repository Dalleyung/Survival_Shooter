using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MobMover : MonoBehaviour
{
    public Transform Target = null;
    public NavMeshAgent NavAgent = null;
    
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NavAgent.SetDestination(Target.position);
    }
}
