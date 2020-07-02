using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Quit : MonoBehaviour
{

    void OnApplicationQuit()
    {
        for (int i = 0; i <= 1000; i++)
        {   
         PlayerPrefs.SetInt("items" + i, Itemmanager.Instance.Items[i]);
        }
        PlayerPrefs.SetInt("Gold", Itemmanager.Instance.Gold);
        PlayerPrefs.SetInt("Dojon", Itemmanager.Instance.Dojon);
        PlayerPrefs.Save();

    }
    bool bPaused = false;

    void OnApplicationPause(bool pause)

    {

        if (pause)

        {

            bPaused = true;
            for (int i = 0; i <= 1000; i++)
            { 
                    PlayerPrefs.SetInt("items" + i, Itemmanager.Instance.Items[i]);
            }
            PlayerPrefs.SetInt("Gold", Itemmanager.Instance.Gold);
            PlayerPrefs.SetInt("Dojon", Itemmanager.Instance.Dojon);
            PlayerPrefs.Save();

        }

        else

        {

            if (bPaused)

            {

                bPaused = false;

            }

        }










    }
}
