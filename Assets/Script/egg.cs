﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    eggs eggss;
    void Update()
    {
        eggss = GameObject.Find("GameManager").GetComponent<eggs>();
        if(Input.GetMouseButton(0)){
            transform.Translate(0, +0.22f, 0);
        }
        else{ 
            transform.Translate(0, -0.15f, 0);
        }
        
        if (transform.position.y < -4f || transform.position.y>+5.0f)
        {
            eggss.life -= 1;
        }

    }
}