using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GpsSet : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Lat;
   
    Gps d;
    void Start()
    {
        d=GameObject.Find("Itemmanger").GetComponent<Gps>();
    }

    // Update is called once per frame
    void Update()
    {
        Lat.text = d.s;
        
    }
}
