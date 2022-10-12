using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void TestFN(int p_a, int p_b);

public class TestButton1 : MonoBehaviour
{
    public void _On_Slider()
    {
        Debug.Log("�����̴�");
    }
    public void _On_Slider2(float p_val)
    {
        Debug.Log($"�����̴�2 : {p_val}");
    }
    public void _On_Slider3(float p_val, int p_val2)
    {
        Debug.Log($"�����̴�3 : {p_val}, {p_val2}");

        //���̶�Ű���� ����(����) �����ϴ¹�
        transform.SetAsFirstSibling();
        transform.SetAsLastSibling();
    }


    protected TestFN m_CallFN = null;

    protected event TestFN m_CallFNEvent = null;

    public void TestFN2(int p_a, int p_b)
    {
        m_CallFNEvent += TestFN2;
        m_CallFNEvent -= TestFN2;

        m_CallFN = TestFN2;

        m_CallFN(10, 20);
    }
    public void _On_TestClick()
    {
        Debug.Log("��ư Ŭ��");
    }

    protected void _On_TestClick2()
    {
        Debug.Log("��ư Ŭ��2");
    }

    protected void _On_TestClick3()
    {
        Debug.Log("��ư Ŭ��3");
    }
}
