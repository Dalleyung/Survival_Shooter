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
        //복제
        //GameObject.Instantiate();
        //코드에서 직접 넣어주는 법
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
        //Ctrl, 마우스 좌클릭
        if (Input.GetButton("Fire1"))
        {
            if (m_CurrentTime < Time.time)
            {
                m_CurrLineSec = LineLifeSec;
                m_CurrentTime = Time.time + m_DelayShot;
                Debug.Log("발사");
                m_LinkLineCom.gameObject.SetActive(true);
                Vector3 frontpos = new Vector3(0, 0, 1);
                frontpos = transform.rotation * frontpos;
                Vector3 endpos = GunEndTran.position + GunEndTran.forward * 100f;
                //Physics.RaycastAll 선상에 있는 모든 물체 정보 불러옴

                RaycastHit hitinfo;
                //선상에 젤 먼저 맞은 물체 정보 불러옴
                if(Physics.Raycast(GunEndTran.position, GunEndTran.forward, out hitinfo, 100))
                {
                    Debug.Log($"충돌 : {hitinfo.transform.name}");
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
                    //코드로 실행하는 법(인스펙터에서 play on awake쓰면 안써도됨)
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
