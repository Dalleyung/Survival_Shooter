using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFire();
    }

    protected float m_CurrentTime = 0f;
    public float m_DelayShot = 1f;
    void UpdateFire()
    {
        //Ctrl, 마우스 좌클릭
        if (Input.GetButton("Fire1"))
        {
            if (m_CurrentTime < Time.time)
            {
                m_CurrentTime = Time.time + m_DelayShot;
                Debug.Log("발사");
            }
        }
    }
}
