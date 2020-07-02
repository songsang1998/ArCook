using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SpecialTimer : MonoBehaviour
{

    public Text timeText;
    public float time;
    public AudioSource t;
    public bool game;
    public GameObject wins;
    public GameObject lose;
    public Text wintext;
    public bool start;
    string so;

    private void Awake()
    {
        start = false;
        game = false;
        time = Random.Range(12, 17);
        so = "목표: "+ Mathf.Ceil(time).ToString();
        timeText.text = so;
    }

    private void Update()
    {
        if (time >=-2 && start == true)
        {
            time -= Time.deltaTime;

        }

        if (game == false && time < -2)
        {
            game = true;
        }


       
    }
    public void Rice()
    {
        if (start)
        {
            if (game == false && time <= 2 && time >= -2)
            {
                game = true;
                for (int i = 0; i <= 1000; i++)
                {

                    if (Itemmanager.Instance.Items[i]==-1)
                    {
                        Itemmanager.Instance.Items[i]= SceneManager.GetActiveScene().buildIndex - 3;
                        break;
                    }
                 
                }
                wintext.text = (SceneManager.GetActiveScene().name + "\r\n을(를) 획득!!");
                wins.SetActive(true);
            }
            else
            {
                    lose.SetActive(true);
            }
        }
        else
        {
            start = true;
            timeText.text = so + " 시작";
            t.Play();
        }
    }

    public void Click4()
    {

        SceneManager.LoadScene("start");
    }
}
