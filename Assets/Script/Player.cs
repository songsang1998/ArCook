﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool lb, rb;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        lb = false;
        rb = false;
        start = false;
    }
    public void Starts()
    {
        start = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (lb == true && transform.position.x > -9)
                transform.Translate(-0.1f, 0, 0);
            if (rb == true && transform.position.x < 9)
                transform.Translate(0.1f, 0, 0);
        }

    }
    public void LButtonDown()
    {

        lb = true;
    }
    public void LButtonUp()
    {

        lb = false;
    }


    public void RButtonDown()
    {

        rb = true;
    }
    public void RButtonUp()
    {

        rb = false;
    }

}
