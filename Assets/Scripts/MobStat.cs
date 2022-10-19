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
            
            
            //GetComponent<MobMover>()?.enabled = false; ?�� ������  null���� Ȯ�����ְ� �� �̰Ŵ� ���� enable�� static�̶� �۵��ȵ�
            //enabled�� false�ع����� update�� �ȵ�
            GetComponent<MobMover>().enabled = false;
            //������ ���� ����Ͽ� ������ ���߾� ����װ����ϰ���
            Debug.LogError("aa");
            StartCoroutine(FallDown());

            //Coroutine cor = StartCoroutine(FallDown());
            //StopCoroutine(cor); //������ �ڷ�ƾ�� ����� �� Ư�� �ڷ�ƾ �����ϴ� �Լ�
            //StopAllCoroutines(); //��� �ڷ�ƾ�� �����ϴ� �Լ�
            //C# Task�� �� ���� �ִ�
        }
    }

    //�ڷ�ƾ �Լ�
    IEnumerator FallDown()
    {
        //������ �ڿ������� �����ϴ� �� Color.Lerp ���� �� ������ : https://www.youtube.com/watch?v=C_f2ChrcSSM
        //��ü���� �ð��� �������� 0�̵Ǹ� ���߰� 1�̵Ǹ� ���� �� ���̰��� �ָ� �������Ե� �������� ȿ���� �ټ��ִ�
        //Time.timeScale = 0


        //���ص� �ð��� ������ �˾Ƽ� �Ʒ��� ������ �ȴ�
        yield return new WaitForSeconds(1.5f);
        //yield return new WaitForSecondsRealtime(1.5f); �����ð� ����

        //�̰� ������ ��� ���߰� Update�� �ϰ� �ٽ� �´�
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

            //yiedl break�� �ڷ�ƾ Ż�⹮
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
