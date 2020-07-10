using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trashShop : MonoBehaviour
{
    public Text s;
    // Start is called before the first frame update
  
    // Update is called once per frame
    public void Open()
    {
        s.text = "이곳은 쓰레기를 소모해 특수재료를 받을 수 있다";
    }
    public void Buy()
    {
        var singleton = Item.Instance;
        for (int i = 0; i <= 1000; i++)
        {
          
            if (Itemmanager.Instance.Items[i] == 24)
            {
                int q = Random.Range(26, 30);
                Itemmanager.Instance.Items[i] = q;
               
                s.text = singleton.itemMap[q].Name + "을(를) 획득햿습니다";
                break;

            }
            else if (Itemmanager.Instance.Items[i] == -1)
            {
                s.text = "쓰레기가 부족합니다(1개필요)";
                break;
            }
        }
    }
}
