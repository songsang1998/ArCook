using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ice : MonoBehaviour
{
    // Start is called before the first frame update

    public Text counts;
    public int count;
  
    public Timer times;
    float lengthx;
    float lengthy;
    public GameObject objs;
    Transform p;
    void Start()
    {
        p=GameObject.Find("Canvas").GetComponent<Transform>();
        Input.multiTouchEnabled = false;
        times = GetComponent<Timer>();
        count = 0;
       
    }
    public void Starts()
    {
        
        StartCoroutine("ices");
    }
    void Update()
    {
        if (count >= 15 && times.time > 0 && times.game == false)
        {
            times.win = true;
        }

        if (times.game == false)
        {
            counts.text = count.ToString();
        }
    }

IEnumerator ices()
    {
        
        lengthx = Random.Range(0
            , Screen.width);

        lengthy = Random.Range(0
            , Screen.height);
        GameObject enemy = (GameObject)Instantiate(objs, new Vector3(lengthx, lengthy, 0f), Quaternion.identity);
        enemy.transform.SetParent(p);
        yield return new WaitForSeconds(0.75f);
        if (times.game == false)
        {
            StartCoroutine("ices");
           
        }
        else
        {
            StopCoroutine("ices");
        }
        
    }
}

