using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Click()
    {
      //  if (PlayerPrefs.HasKey("Play"))
        ///{
            SceneManager.LoadScene("start");
        //}
        //{
          //  PlayerPrefs.SetInt("Play", 1);
           // SceneManager.LoadScene("plolog");
        //}
    }
    public void Click2()
    {
        if (Itemmanager.Instance.Dojon > 0)
        {
            SceneManager.LoadScene("camera");
            Itemmanager.Instance.Dojon--;
        }
    }
    public void Click3()
    {
        for (int i = 0; i <= 1000; i++)
        {
            PlayerPrefs.SetInt("items" + i, Itemmanager.Instance.Items[i]);
        }
        PlayerPrefs.SetInt("Gold", Itemmanager.Instance.Gold);
        PlayerPrefs.SetInt("Dojon", Itemmanager.Instance.Dojon);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Server");
    }
    
}
