using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour
{
    // Start is called before the first frame update
    Potato bugss;
    void Start()
    {
        bugss = GameObject.Find("GameManager").GetComponent<Potato>();
    }

    // Update is called once per frame

    void Update()
    {

        transform.Translate(0, -0.15f, 0);


        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.name == "potato")
        {
            bugss.life--;
            Destroy(gameObject);
        }
    }

}