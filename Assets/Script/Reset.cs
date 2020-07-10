using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void Resets()
    {
        Itemmanager.Instance.Gold = 10000;
        Itemmanager.Instance.Dojon = 10;
        for (int i = 0; i <= 1000; i++)
        {
            if (Itemmanager.Instance.Items[i] != -1)
            {
                Itemmanager.Instance.Items[i] = -1;
            }
            else
            {
                break;
            }
        }
            PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
