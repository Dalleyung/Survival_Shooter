using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float LerpT = 8f;
    protected Vector3 m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_Offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CamMoveUpdate();
    }

    void CamMoveUpdate()
    {
        Vector3 targetPos = target.position;
        //deltaTime ���� ���� Update�� ���� �ֱⰡ ���� �ʾƼ�(���� ��Ȳ�� �ְ� ���� ��� ����)
        //Lerp ��������, <-�̰ź��� ����Ƽ cinemachine�� ���� ����(������ ���� �ű⶧���� �м��غ��� ����)
        targetPos = Vector3.Lerp(transform.position, targetPos - m_Offset, LerpT * Time.deltaTime);
        this.transform.position = targetPos;
    }


}
