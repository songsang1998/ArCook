using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money : MonoBehaviour
{
    Text s;
    public Text q;
    M M;
    public GameObject clears;
    // Start is called before the first frame update
    void Start()
    {
        s=gameObject.GetComponent<Text>();
        M = Itemmanager.Instance.GetComponent<M>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Itemmanager.Instance.clear)
        {
            s.text = "빚:" + Itemmanager.Instance.Gold.ToString();
        }
        else
        {
            s.text = "점수(돈):" + (Itemmanager.Instance.Gold * -1).ToString();
            if (!clears.gameObject.activeSelf)
            {
                clears.SetActive(true);
            }
        }
    }
}
