using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money : MonoBehaviour
{
    Text s;
    public Text q;
    M M;
    // Start is called before the first frame update
    void Start()
    {
        s=gameObject.GetComponent<Text>();
        M = Itemmanager.Instance.GetComponent<M>();
    }

    // Update is called once per frame
    void Update()
    {
        s.text = "빚:" + Itemmanager.Instance.Gold.ToString();
        q.text = "M:count" + M.count;
    }
}
