using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Don : MonoBehaviour
{
    // Start is called before the first frame update\\
    int requst;
     public AudioClip[] bgms;
      public static Don instance = null;
   
    //Static instance of GameManager which allows it to be accessed by any other script.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void OnSceneLoaded(Scene scene, LoadSceneMode level)
    {

      
        if (scene.buildIndex >= 0 && scene.buildIndex <= 2)
        {
            
            if (requst != 0)
            {
                GetComponent<AudioSource>().clip = bgms[0];
                GetComponent<AudioSource>().Play();
                requst = 0;

            }
        }
        else 
        {
            if (requst != 1) {
                GetComponent<AudioSource>().clip = bgms[1];
                GetComponent<AudioSource>().Play();
                
                requst = 1;
                    }
        }

    }

   
}
