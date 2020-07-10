using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Invatoli : MonoBehaviour
{
    Itemmanager user;
    static int a;
    // Start is called before the first frame update
    public void Start()
    {
        user = GameObject.Find("Itemmanger").GetComponent<Itemmanager>();
        a = 0;

    }
  
    
    public void ItemOpen()
    {

        Transform parrent;

        parrent = GameObject.Find("Canvas").transform.Find("Panel").transform.GetChild(0).transform.GetChild(0).transform;
        for (int i = 0; i < parrent.childCount; i++)
        {

            Destroy(parrent.transform.GetChild(i).gameObject);
        }
        a = 0;
        for (int i=0; i<=1000; i++)
        {
           
            int itemnu = Itemmanager.Instance.Items[i];
            if(itemnu!= -1)
            {
                
                GameObject cardpre = Instantiate(user.ItemImage[itemnu], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                cardpre.name = a.ToString();
                cardpre.transform.SetParent(parrent);
                a++;
            }
            else
            {
                break;
            }

        }

    }
}
