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
    protected MobStat m_MobStat = null;
    protected Animator LinkAnimator = null;
    
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        LinkAnimator = GetComponent<Animator>();
        m_MobStat = GetComponent<MobStat>();
    }

    void Update()
    {
        if (!m_MobStat.IsDie())
        {
            NavAgent.SetDestination(Target.position);
        }

        //magnitude가 길이를 나타냄
        float length = NavAgent.velocity.magnitude;

        if(length > 0.01f)
        {
            LinkAnimator.SetBool("Move", true);
            LinkAnimator.SetFloat("AniSpeed", 1);
        }
        else
        {
            LinkAnimator.SetBool("Move", false);
            LinkAnimator.SetFloat("AniSpeed", 1);
        }
    }
}
