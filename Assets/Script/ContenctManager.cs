using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class ContenctManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Select;
    int Chose1;
    int whoChose1;
    int Chose2;
    int whoChose2;
    public Text so;
    public GameObject soso;
    string sw;
    int ss;
    bool mix;
    public List<int> CItem = new List<int>();
    public GameObject Sellpage;
    public GameObject givepage;
    // Update is called once per frame
    public void Sell()
    {
        var singleton = Item.Instance;
        CItem = Itemmanager.Instance.Items;
        string u = Select.name;
       
        int r = int.Parse(u);
        Destroy(Select);
        
        for (int s=r; CItem[s]!=-1; s++)
        {
            CItem[s] = CItem[s+1];
        }
        whoChose1 = Select.GetComponent<Itemsetting>().Number;
        Itemmanager.Instance.Gold -= singleton.itemMap[whoChose1].Gold;
        Sellpage.SetActive(true);
        Sellpage.transform.Find("massage").GetComponent<Text>().text = singleton.itemMap[whoChose1].Gold.ToString()+ "원에"+ singleton.itemMap[whoChose1].Name+"을(를) 판매했습니다";

    }

    public void Mix()
    {
        Chose1 = int.Parse(Select.name);
        var singleton = Item.Instance;
        whoChose1 = singleton.itemMap[Select.GetComponent<Itemsetting>().Number].Number;
    }

    public void Mix2() {
        CItem = Itemmanager.Instance.Items;
        Chose2 = int.Parse(Select.name);
        var singleton = Item.Instance;
        whoChose2 = singleton.itemMap[Select.GetComponent<Itemsetting>().Number].Number;
        if (Chose1 == Chose2)
        {
            GameObject.Find("Canvas").transform.Find("mixmain").gameObject.SetActive(true);
            so.text = "하나의 재료를 두번 넣었습니다";
            soso.GetComponent<Image>().sprite = soso.GetComponent<image>().a[99];

        }
        else
        {
            mix = false;
            int mixnumber = whoChose1 * whoChose2;
            
            for(int i=0;  i<singleton.max; i++)
            {
                
                if (singleton.itemMap[i].Number == mixnumber)
                {
                    sw= singleton.itemMap[i].Name;
                    ss = i;
                    mix = true;
                    
                    break;
                    
                }
            }

            if (!mix)
            {
                sw = "쓰레기";
                ss = 24;
                mix = true;
               
            }
          
            if (Chose1 > Chose2)
            {
              
                CItem[Chose2] = ss;
               

                for (int s = Chose1; CItem[s] != -1; s++)
                {
                    
                    CItem[s] = CItem[s + 1];
                }

            }
            else
            {
               
                CItem[Chose1] = ss;
             
                for (int q = Chose2; CItem[q] != -1; q++)
                {
                    CItem[q] = CItem[q + 1];
                   
                }
            }

            GameObject.Find("Canvas").transform.Find("mixmain").gameObject.SetActive(true);
            so.text = sw + "이(가) 완성 되었습니다.";
            soso.GetComponent<Image>().sprite = soso.GetComponent<image>().a[ss];


        }


    }

    public void Trade()
    {
        var singleton = Item.Instance;
        CItem = Itemmanager.Instance.Items;
        Chose1 = int.Parse(Select.name);
        
        
        string u = Select.name;
     
        int r = int.Parse(u);
        for (int s = r; CItem[s] != -1; s++)
        {
            CItem[s] = CItem[s + 1];
        }
        whoChose1 = Select.GetComponent<Itemsetting>().Number;
        givepage.SetActive(true);
        PhotonView pv =GameObject.Find("StartManager").GetComponent<PhotonView>();
        int t = Select.GetComponent<Itemsetting>().Number;

        pv.RPC("Trade", RpcTarget.Others, whoChose1);
        
        givepage.transform.Find("massage").GetComponent<Text>().text = singleton.itemMap[whoChose1].Name + "을 주었습니다";
    }

    

}
