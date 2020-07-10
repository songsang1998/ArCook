
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milks : MonoBehaviour
{
    // Start is called before the first frame update
    milk milkss;
    void Start()
    {
        milkss = GameObject.Find("GameManager").GetComponent<milk>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, -0.1f, 0);


        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.transform.name == "Cow")
        {
            milkss.count++;
            Destroy(gameObject);
        }
    }

}