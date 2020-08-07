using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Pocker s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PanelOn()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void Update()
    {


        if (s.you ==-1)
        {
            if (s.ship > s.chip)
            {
                
                for(int i=0; i<s.chip; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < s.ship; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }

        }else
        {
            if (s.ship > s.chip-s.you)
            {
                for (int i = 0; i < s.chip - s.you; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < s.ship; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }

    }
}
