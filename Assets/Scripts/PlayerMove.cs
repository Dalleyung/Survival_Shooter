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
    //�ν�����â���� ������ϴ� ��(�ֱ������� ������Ʈ �ϴ� ������ ������ϸ� ����ó���� ����ȭ�� ���� ����)
    [SerializeField] //protect, private�� �ν����Ϳ��� ���̰��ϴ� ��, �ݴ��� [HideInInspector]�� ����
    protected Vector3 m_TempMousePos;
    [SerializeField]
    protected float m_Radian;

    public Camera LinkCamera;
    void UpdateMouseRotation()//�߿�
    {
        m_CenterScreenPos = LinkCamera.WorldToScreenPoint(transform.position);

        //Debug.Log(Input.mousePosition);
        m_TempMousePos = Input.mousePosition;//�ν����Ϳ��� Ȯ���ϱ����� �ڵ�

        Vector3 temppos = Input.mousePosition - m_CenterScreenPos;
        m_Radian = Mathf.Atan2(temppos.y, temppos.x);
        m_Radian = m_Radian * Mathf.Rad2Deg;//������ ������ ��ȯ, �ݴ��� Deg2Rad ������ �������� ��ȯ

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
