using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSet : MonoBehaviour
{
  
    
    int number;
    public Text so;
    public GameObject soso;
    

    // Start is called before the first frame update
   
    bool mixs;
    public void Mix()
    {
        mixs = false;

        
       

      
      

        if (!mixs)
        {
            number = 1;
            qr("쓰레기", number);
        }
        PlayerPrefs.SetInt("data" + number, 1);
        PlayerPrefs.Save();
    }

    public void qr(string s,int ss)
    {
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
        so.text = (s + "이(가) 완성 되었습니다.");
        soso.GetComponent<Image>().sprite = soso.GetComponent<image>().a[ss];
        mixs = true;
        
         
    }
    // Update is called once per frame
    
}
