using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkin : MonoBehaviour
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
        p = GameObject.Find("Canvas").GetComponent<Transform>();
        Input.multiTouchEnabled = false;
        times = GetComponent<Timer>();
        count = 100;
        Hit();
    }
    void Update()
    {
        if (count < 0 && times.game == false && times.time > 0)
        {
            count = 0;
        }
        if (count ==0 && times.time > 0 && times.game == false)
        {
            times.win = true;
        }

        if (times.game == false)
        {
            counts.text = count.ToString();
        }
    }

    public void Hit()
    {
        
            lengthx = Random.Range(Screen.width / 4
                , Screen.width / 4 * 3);

            lengthy = Random.Range(Screen.height/4
                , Screen.height/2);
            GameObject enemy = (GameObject)Instantiate(objs, new Vector3(lengthx, lengthy, 0f), Quaternion.identity);
            enemy.transform.SetParent(p);
        

    }
}

