﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cardlist : MonoBehaviour
{
    public Sprite [] dr;
    public Pocker y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (y.game == true)
        {
            GetComponent<Image>().sprite = dr[y.waiorcard];
        }
    }
}
