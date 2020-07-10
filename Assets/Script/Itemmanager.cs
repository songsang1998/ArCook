using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Itemmanager : MonoBehaviour
{
    

    public static Itemmanager Instance;
    public int Gold;
    public int Dojon;
    public bool clear;
    DateTime dt; 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        clear = false;
        
        for (int i = 0; i <= 1000; i++)
        {
            if (PlayerPrefs.HasKey("items" + i))
            {
                Items[i] = PlayerPrefs.GetInt("items" + i);
            }
            else
            {
                Items[i] = -1;
            }
        }

        if (PlayerPrefs.HasKey("Gold"))
        {
            Gold = PlayerPrefs.GetInt("Gold");
            if (Gold <= 0)
            {
                clear = true;
            }
        }
        else
        {
            Gold = 10000;
            PlayerPrefs.SetInt("Gold", Gold);
            PlayerPrefs.Save();
        }
        
        if (PlayerPrefs.HasKey("Dojon"))
        {


            dt= DateTime.Today;
            string MDays = PlayerPrefs.GetString("MDay");
            if (MDays != dt.Month.ToString() + dt.Day.ToString())
            {
                Dojon = 10;
                PlayerPrefs.SetInt("Dojon", 10);
                MDays = dt.Month.ToString() + dt.Day.ToString();
                PlayerPrefs.SetString("MDay", MDays);
                PlayerPrefs.Save();
            }
            else
            {
                Dojon = PlayerPrefs.GetInt("Dojon");
            }
           

        }
        else
        {

            PlayerPrefs.SetString("MDay", dt.Month.ToString() + dt.Day.ToString());
            PlayerPrefs.Save();
            Dojon = 10;
        }
    }
    public List<int> Items = new List<int>();
    public GameObject[] ItemImage;
    
    public void WhatClear()
    {
        if (Gold <= 0)
        {
            clear = true;
        }
    }
    public void Set()
    {   /*
        for (int i = 0; i <= 1000; i++)
        {
            if (PlayerPrefs.HasKey("items" + i))
            {
               Items[i] = PlayerPrefs.GetInt("items" + i);
            }
            else
            {
                Items[i] = -1;
            }
        }*/

    }
    // Start is called before the first frame update


    // Update is called once per frame



}
