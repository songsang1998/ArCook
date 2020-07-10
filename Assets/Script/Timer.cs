
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    public Text timeText;
    public float time;
    public bool win;
    public bool game;
    public GameObject wins;
    public GameObject lose;
    public Text wintext;
    bool start;
    private void Awake()
    {
        win = false;
        game = false;
        time = 20f;
        start = false;
    }
    public void Starts()
    {
        start = true;
    }
    private void Update()
    {
        if (start)
        {
            if (win == true && game == false)
            {
                game = true;
                for (int i = 0; i <= 1000; i++)
                {
                    if (Itemmanager.Instance.Items[i] == -1)
                    {
                        Itemmanager.Instance.Items[i] = SceneManager.GetActiveScene().buildIndex - 3;
                        break;
                    }
                }
                wintext.text = (SceneManager.GetActiveScene().name + "\r\n을(를) 획득!!");
                wins.SetActive(true);

            }
            if (time > 0 && win == false && game == false)
            {
                time -= Time.deltaTime;

            }


            if (time <= 0 && win == false && game == false)
            {
                game = true;

                lose.SetActive(true);

            }

        }
        timeText.text = "시간: " + Mathf.Ceil(time).ToString();
        
    }

    public void Click4(){

    SceneManager.LoadScene("start");    
    }
}
