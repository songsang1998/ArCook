using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rellol : MonoBehaviour
{
    Text s;
    // Start is called before the first frame update
    void Start()
    {
        s = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        s.text = "도전횟수:" + Itemmanager.Instance.Dojon.ToString()+
            "\n 최대 10, 다음날 마다 초기화,30걸음마다 +1";
    }
}
