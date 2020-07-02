using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemsetting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject s;
    ContenctManager csmanager;
    Text Name;
    Text main;
    public int Number;
   
    void Start()
    {
        csmanager = GameObject.Find("Contenct").GetComponent<ContenctManager>();
        
       s = GameObject.Find("Panel").transform.Find("item").gameObject;
       Name= s.transform.Find("Name").gameObject.GetComponent<Text>();
       main= s.transform.Find("Main").gameObject.GetComponent<Text>();
      
    }

    // Update is called once per frame
    public void ItemSee()
    {
        var singleton = Item.Instance;
        s.SetActive(true);
        Name.text=singleton.itemMap[Number].Name;
        main.text = singleton.itemMap[Number].maintext;
        csmanager.Select = gameObject;

    }

}
