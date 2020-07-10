using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eggs : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counts;
    public int life;

    public LoseTimer times;
    float lengthx;
    float lengthy;

    Transform p;
    void Start()
    {
        p = GameObject.Find("Canvas").GetComponent<Transform>();
        Input.multiTouchEnabled = false;
        times = GetComponent<LoseTimer>();
        life = 30;
      
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
}
