using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobStat : MonoBehaviour
{
    public Animator LinkAnimator = null;
    public NavMeshAgent NavAgent = null;

    public int HP = 2;
    public float fallSpeed = 1f;

    public bool IsDie()
    {
        if(HP <= 0)
        {
            return true;
        }
        return false;
    }

    public void SetDamage(int p_dmg)
    {
        HP -= p_dmg;

        if(HP <= 0)
        {
            LinkAnimator.SetTrigger("Die");
            NavAgent.isStopped = true;
            NavAgent.enabled = false;
            
            
            //GetComponent<MobMover>()?.enabled = false; ?를 붙히면  null인지 확인해주게 됨 이거는 현재 enable이 static이라 작동안됨
            //enabled를 false해버리면 update가 안됨
            GetComponent<MobMover>().enabled = false;
            //강제로 에러 출력하여 게임을 멈추어 디버그가능하게함
            Debug.LogError("aa");
            StartCoroutine(FallDown());

            //Coroutine cor = StartCoroutine(FallDown());
            //StopCoroutine(cor); //여러개 코루틴을 사용할 때 특정 코루틴 정지하는 함수
            //StopAllCoroutines(); //모든 코루틴을 정지하는 함수
            //C# Task를 쓸 때도 있다
        }
    }

    //코루틴 함수
    IEnumerator FallDown()
    {
        //색깔을 자연스럽게 변경하는 법 Color.Lerp 쓰면 됨 참고영상 : https://www.youtube.com/watch?v=C_f2ChrcSSM
        //전체적인 시간을 조정가능 0이되면 멈추고 1이되면 정상 그 사이값을 주면 느려지게됨 느려지는 효과를 줄수있다
        //Time.timeScale = 0


        //정해둔 시간이 지나면 알아서 아래가 실행이 된다
        yield return new WaitForSeconds(1.5f);
        //yield return new WaitForSecondsRealtime(1.5f); 실제시간 버전

        //이걸 만나면 잠깐 멈추고 Update를 하고 다시 온다
        yield return null;

        while (true)
        {
            Vector3 temppos = transform.position;
            temppos.y -= (Time.deltaTime * fallSpeed);
            transform.position = temppos;

            if(temppos.y <= -5f)
            {
                break;
            }

            //yiedl break는 코루틴 탈출문
            yield return null;
        }
        GameObject.Destroy(gameObject);
    }

    private void Awake()
    {
        LinkAnimator = GetComponent<Animator>();
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
