using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveY; 
    public float moveX;
    public float moveX_for_move;
    public float moveZ;
    public float moveY_for_move;
    private bool is_moveZW;
    private bool is_moveZS;
    private bool is_moveXA;
    private bool is_moveXD;
    private bool is_moveYSHIFT;
    private bool is_moveYSPACE;
    private bool is_moveX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	moveY = Input.GetAxis("Mouse Y");
    	moveX = Input.GetAxis("Mouse X");
    	//движение на кнопку "W"
    	if (Input.GetKeyDown(KeyCode.W)){
    		is_moveZW = true;
    	}
    	if (Input.GetKeyUp(KeyCode.W)){
    		is_moveZW = false;
    	}
    	if (is_moveZW){
    		moveZ += 0.5f;
    	}
        //движение на кнопку "S"
    	if (Input.GetKeyDown(KeyCode.S)){
    		is_moveZS = true;
    	}
    	if (Input.GetKeyUp(KeyCode.S)){
    		is_moveZS = false;
    	}
    	if (is_moveZS){
    		moveZ += -0.5f;
    	}
        //движение на кнопку "D"
        if (Input.GetKeyDown(KeyCode.D)){
            is_moveXD = true;
        }
        if (Input.GetKeyUp(KeyCode.D)){
            is_moveXD = false;
        }
        if (is_moveXD){
            moveX_for_move += 0.5f;
        }
        //движение на кнопку "A"
        if (Input.GetKeyDown(KeyCode.A)){
            is_moveXA = true;
        }
        if (Input.GetKeyUp(KeyCode.A)){
            is_moveXA = false;
        }
        if (is_moveXA){
            moveX_for_move += -0.5f;
        }
        //движение на кнопку "SHIFT"
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            is_moveYSHIFT = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            is_moveYSHIFT = false;
        }
        if (is_moveYSHIFT){
            moveY_for_move += -0.5f;
        }
        //движение на кнопку "Space"
        if (Input.GetKeyDown(KeyCode.Space)){
            is_moveYSPACE = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            is_moveYSPACE = false;
        }
        if (is_moveYSPACE){
            moveY_for_move += 0.5f;
        }
    	transform.position = new Vector3(transform.position.x + moveX_for_move, transform.position.y + moveY_for_move,transform.position.z + moveZ);
        transform.Rotate((moveY*-1) * 12f,moveX * 12f,0f);
        moveX_for_move = 0f;
        moveY_for_move = 0f;
        moveZ = 0f;
    }
}
