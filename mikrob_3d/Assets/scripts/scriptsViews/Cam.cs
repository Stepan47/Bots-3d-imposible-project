using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float sensitivityX =1f ;
    public float sensitivityY=1f;
    float rotX = 0f, rotY=0f;

    public float moveSpeed = 5f, runSpeed = 15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rotX += Input.GetAxis("Mouse X") * sensitivityX;
        rotY += Input.GetAxis("Mouse Y") * sensitivityY;
        //Debug.Log(string.Format("axis:{0}, {1}; rot X:{2}, y:{3}", Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),rotX,rotY));

        if(rotX>360){rotX-=360;}
        else if(rotX<0){rotX+=360;}//Защита от переполнения

        if(rotY>90){rotY=90;}
        else if(rotY<-90){rotY=-90;}

        

        transform.rotation = Quaternion.Euler(rotY, rotX, 0);
        //Debug.Log(string.Format("x rot pos: {0}, y rot pos: {1}.", rotX, rotY));

        if(Input.GetKey(KeyCode.LeftShift)){
            if(Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

            if(Input.GetKey(KeyCode.S))
                transform.Translate(-Vector3.forward * runSpeed * Time.deltaTime);

            /*if(Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.up, -runSpeed * Time.deltaTime);

            if(Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.up, runSpeed * Time.deltaTime);*/}
        else{
            if(Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if(Input.GetKey(KeyCode.S))
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

            /*if(Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.up, -moveSpeed * Time.deltaTime);

            if(Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.up, moveSpeed * Time.deltaTime);*/}
    }
}
