using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potato : MonoBehaviour
{
    // Start is called before the first frame update

    public Text counts;
    public int life;

    public LoseTimer times;
    float lengthx;
    float lengthy;
    public GameObject objs;
    Transform p;
    void Start()
    {
        p = GameObject.Find("Canvas").GetComponent<Transform>();
        Input.multiTouchEnabled = false;
        times = GetComponent<LoseTimer>();
        life = 3;
        StartCoroutine("Potatos");
    }
    void Update()
    {
        if (life <= 0 && times.game == false)
        {
            times.win = false;
        }
        
        if (times.game == false)
        {
            
            counts.text = life.ToString();
        }
    }

    IEnumerator Potatos()
    {

        lengthx = Random.Range(-9, 9);


        GameObject enemy = (GameObject)Instantiate(objs) as GameObject;
        enemy.transform.position = new Vector2(lengthx, 8f);
        yield return new WaitForSeconds(0.8f);
        if (times.game == false)
        {
            StartCoroutine("Potatos");

        }
        else
        {
            StopCoroutine("Potatos");
        }

    }
}

