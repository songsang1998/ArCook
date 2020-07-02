using UnityEngine;
using System.Collections;
public class sky : MonoBehaviour
{

    public float ScrollSpeed = 0.5f;
    float Offset;
    
    void Update()
    {
        
        Offset += Time.deltaTime * ScrollSpeed;
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0);
        if (Offset >= 0.75)
        {
            Offset = 0;
        }
    }
}

