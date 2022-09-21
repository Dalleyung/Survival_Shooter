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
        //deltaTime 쓰는 이유 Update가 전부 주기가 같지 않아서(쓰는 상황이 있고 없는 경우 있음)
        //Lerp 선형보간, <-이거보단 유니티 cinemachine을 요즘 쓴다(가져다 쓰는 거기때문에 분석해보면 좋음)
        targetPos = Vector3.Lerp(transform.position, targetPos - m_Offset, LerpT * Time.deltaTime);
        this.transform.position = targetPos;
    }


}
