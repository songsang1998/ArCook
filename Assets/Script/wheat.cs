using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wheat : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPos;
    
    Vector2 endPos;
    public Text counts;
    int count;
    bool start;
   

    Timer times;
    float lengthx;
    float lengthy;
    public void Starts()
    {
        start = true;
      
    }
    void Start()
    {
        Input.multiTouchEnabled = false;
        times = GetComponent<Timer>();
        count = 0;
        start = false;
        
    }
    void Update()
    {
        if (start)
        {
            if (count >= 700 && times.time > 0 && times.game == false)
            {
                times.win = true;
            }

            if (Input.GetMouseButtonDown(0) && times.game == false)
            {

                StartCoroutine("move");

            }
        }
        counts.text = count.ToString();
    }

IEnumerator move()
    {
        startPos = Input.mousePosition;
        yield return new WaitForSeconds(0.0001f);
        endPos = Input.mousePosition;
        lengthx = Mathf.Abs(endPos.x - startPos.x)/80;
        lengthy = Mathf.Abs(endPos.y - startPos.y)/80;
        if (count <700)
        {
            count += (int)(lengthx + lengthy);
        }
        else if (count > 700)
        {
            count = 700;
        }

        if (Input.GetMouseButton(0) && times.game == false)
        {
            StartCoroutine("move");
        }


    }
}

