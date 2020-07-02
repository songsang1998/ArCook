using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class milk : MonoBehaviour
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
        count = 0;
        StartCoroutine("milks");
    }
    void Update()
    {
        if (count >= 10 && times.time > 0 && times.game == false)
        {
            times.win = true;
        }

        if (times.game == false)
        {
            counts.text = count.ToString();
        }
    }

    IEnumerator milks()
    {

        lengthx = Random.Range(-6, 7);

       
        GameObject enemy = (GameObject)Instantiate(objs) as GameObject;
        enemy.transform.position = new Vector2(lengthx, 7f);
        yield return new WaitForSeconds(1.5f);
        if (times.game == false)
        {
            StartCoroutine("milks");

        }
        else
        {
            StopCoroutine("milks");
        }

    }
}

