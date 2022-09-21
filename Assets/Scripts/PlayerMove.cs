using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        m_CenterScreenPos.x = Screen.width * 0.5f;
        m_CenterScreenPos.y = Screen.height * 0.5f;
    }
    [SerializeField]
    protected Vector3 m_CenterScreenPos;
    //인스펙터창에서 디버그하는 법(주기적으로 업데이트 하는 변수는 디버그하면 연산처리에 과부화가 오기 때문)
    [SerializeField] //protect, private도 인스펙터에서 보이게하는 법, 반대인 [HideInInspector]도 있음
    protected Vector3 m_TempMousePos;
    [SerializeField]
    protected float m_Radian;

    public Camera LinkCamera;
    void UpdateMouseRotation()//중요
    {
        m_CenterScreenPos = LinkCamera.WorldToScreenPoint(transform.position);

        //Debug.Log(Input.mousePosition);
        m_TempMousePos = Input.mousePosition;//인스펙터에서 확인하기위한 코드

        Vector3 temppos = Input.mousePosition - m_CenterScreenPos;
        m_Radian = Mathf.Atan2(temppos.y, temppos.x);
        m_Radian = m_Radian * Mathf.Rad2Deg;//라디안을 각도로 변환, 반대인 Deg2Rad 각도를 라디안으로 변환

        transform.rotation = Quaternion.Euler(0f, -m_Radian + 90, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        UpdateMouseRotation();
    }

    void PlayerMovement()
    {
        float xx = Input.GetAxis("Horizontal");
        float yy = Input.GetAxis("Vertical");

        Vector3 temppos = new Vector3(xx * Time.deltaTime * speed, 0, yy * Time.deltaTime * speed);
        temppos = transform.position + temppos;
        transform.position = temppos;

        if(xx != 0f || yy != 0f)
        {
            Animator ani = this.GetComponent<Animator>();
            ani.SetBool("MMover", true);
        }
        else
        {
            Animator ani = this.GetComponent<Animator>();
            ani.SetBool("MMover", false);
        }
    }
}
