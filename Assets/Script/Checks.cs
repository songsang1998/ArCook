using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checks : MonoBehaviour
{
    Checkin che;
    float HitCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        che = GameObject.Find("GameManager").GetComponent<Checkin>();
        
    }

    public void Update()
    {
        if (HitCount < 1)
        {
            HitCount = 1;
        }
        else if(HitCount >1 )
        {
            HitCount -= (Time.deltaTime*2);
        }
    }
    // Update is called once per frame
    public void Count()
    {   

        if (che.times.time > 0 && che.times.game == false)
        {
            che.count -= (int)HitCount;
            Destroy(gameObject);
            che.Hit();
        }
    }
}
