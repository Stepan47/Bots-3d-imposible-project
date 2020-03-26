using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGame : MonoBehaviour
{
    public float y = 0f;
    public float add = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(y+=add,0, 0);
        if(y>360f){y-=360f;}
        else if(y<0f){y+=360f;}
    }
}
