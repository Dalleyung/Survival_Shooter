using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    protected float m_CurrentTime = 0f;
    public float m_DelayShot = 1f;
    public Transform GunEndTran = null;
    [SerializeField]
    protected LineRenderer m_LinkLineCom = null;
    public float LineLifeSec = 0.1f;
    protected float m_CurrLineSec = 0f;
    public GameObject HitParticle = null;
    void Awake()
    {
        //����
        //GameObject.Instantiate();
        //�ڵ忡�� ���� �־��ִ� ��
        //m_LinkLineCom = GameObject.Find("Line").GetComponent<LineRenderer>();
        m_LinkLineCom = GameObject.FindObjectOfType<LineRenderer>();
        m_LinkLineCom.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFire();
        UpdateLineRender();
        UpdateLineLife();
    }

    void UpdateLineRender()
    {
        
    }

    void UpdateLineLife()
    {
        m_CurrLineSec -= Time.deltaTime;

        if(m_CurrLineSec <= 0)
        {
            m_LinkLineCom.gameObject.SetActive(false);
        }
    }

    void UpdateFire()
    {
        //Ctrl, ���콺 ��Ŭ��
        if (Input.GetButton("Fire1"))
        {
            if (m_CurrentTime < Time.time)
            {
                m_CurrLineSec = LineLifeSec;
                m_CurrentTime = Time.time + m_DelayShot;
                Debug.Log("�߻�");
                m_LinkLineCom.gameObject.SetActive(true);
                Vector3 frontpos = new Vector3(0, 0, 1);
                frontpos = transform.rotation * frontpos;
                Vector3 endpos = GunEndTran.position + GunEndTran.forward * 100f;
                //Physics.RaycastAll ���� �ִ� ��� ��ü ���� �ҷ���

                RaycastHit hitinfo;
                //���� �� ���� ���� ��ü ���� �ҷ���
                if(Physics.Raycast(GunEndTran.position, GunEndTran.forward, out hitinfo, 100))
                {
                    Debug.Log($"�浹 : {hitinfo.transform.name}");
                    if (hitinfo.transform.tag == "Mob")
                    {
                        //hitinfo.transform.GetComponent<Animator>();
                        //GameObject.Destroy(hitinfo.transform.gameObject);
                        MobStat stat = hitinfo.transform.GetComponent<MobStat>();
                        if(stat != null)
                        {
                            stat.SetDamage(1);
                        }
                    }

                    endpos = hitinfo.point;

                    GameObject obj = GameObject.Instantiate(HitParticle, endpos, Quaternion.identity);
                    //�ڵ�� �����ϴ� ��(�ν����Ϳ��� play on awake���� �Ƚᵵ��)
                    //obj.GetComponent<ParticleSystem>().Play()
                    obj.transform.LookAt(obj.transform.position - hitinfo.normal, Vector3.up);

                    GameObject.Destroy(obj, 2f);
                }

                m_LinkLineCom.SetPosition(0, GunEndTran.position);
                m_LinkLineCom.SetPosition(1, endpos);
                //Physics.Raycast();
                //Physics.CapsuleCast();
                //Physics.BoxCast();

                //Physics.OverlapSphere();
                //Physics.OverlapBox();
                //Physics.OverlapCapsule();
            }
        }
    }
}
