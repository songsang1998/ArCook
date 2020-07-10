using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class M : MonoBehaviour
{
    float cut = 0.20f;
    float cutup = 0.49f;
    public float a;
    public float b;
    public float c;
 

    public int count;
    bool countss;
    void Awake()
    {
        Input.gyro.enabled = true;
    }
    void Start()
    {
        countss = true;
      
    }

    void Update()
    {
        a = Input.gyro.rotationRateUnbiased.x;
        b = Input.gyro.rotationRateUnbiased.y;
        c = Input.gyro.rotationRateUnbiased.z;

        if (Itemmanager.Instance.Dojon < 10)
        {
           
            Countsss();
        }
        if (Itemmanager.Instance.clear)
        {
            Itemmanager.Instance.Dojon = 9999;
        }
        
    }
    void Countsss()
    {
        if ((cut < Mathf.Abs(b) && Mathf.Abs(b) < cutup && cut < Mathf.Abs(a) && Mathf.Abs(a) < cutup && cut < Mathf.Abs(c) && Mathf.Abs(c) < cutup) && countss == true)
        {
            countss = false;
            StartCoroutine(Counts());
        }
    }
    IEnumerator Counts()
    {
        count++;
        
        yield return new WaitForSeconds(0.64f);
        countss = true;
        if (count == 30)
        {
            
          Itemmanager.Instance.Dojon += 1;
          count=0;
        }
    }
}
