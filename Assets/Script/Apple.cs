﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counts;
    int count;
    
    Timer times;
    
    void Start()
    {
        Input.multiTouchEnabled = true;
        times = GetComponent<Timer>();
        count = 0;
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && times.game == false)
        {
            count++;
            if (count >= 35 && times.time>0 )
            {
                times.win = true;
            }
        }
        counts.text = count.ToString();
    }
}