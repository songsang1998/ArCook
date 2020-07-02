using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ices : MonoBehaviour
{
    ice ics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.3f);
        ics = GameObject.Find("GameManager").GetComponent<ice>();
    }

    // Update is called once per frame
    public void Count()
    {
        if (ics.times.time > 0 && ics.times.game == false)
        {
            ics.count++;
            Destroy(gameObject);
        }
    }
}
