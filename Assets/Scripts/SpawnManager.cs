using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float delaySec = 1f;
    public GameObject mobPrefab = null;
    
    void CreateMob()
    {
        GameObject copyObj = GameObject.Instantiate(mobPrefab);
        copyObj.transform.position = transform.position;
        copyObj.GetComponent<MobMover>().Target = GameObject.FindObjectOfType<PlayerFire>().transform;
    }

    IEnumerator DelayCoroutine()
    {
        while (true)
        {
            //1�ʰ� ���߰� �����ٽ���
            yield return new WaitForSeconds(delaySec);
            CreateMob();
        }
    }

    void Start()
    {
        StartCoroutine(DelayCoroutine());
    }

    
    void Update()
    {
        
    }
}
