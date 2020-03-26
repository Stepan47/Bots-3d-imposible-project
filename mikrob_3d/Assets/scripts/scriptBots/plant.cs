using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ygol1;
    public GameObject ygol2;
    public float yPos = 100;
    public GameObject Origin;
    public int FastSpawn=700000;
    int i =0;
    float xLeft, xRight, zLeft, zRight;
    void Start()
    {
        xLeft = ygol1.transform.position.x; 
        zLeft = ygol1.transform.position.z;
        xRight = ygol2.transform.position.x; 
        zRight = ygol2.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(i>=FastSpawn){
            Instantiate(Origin, new Vector3(Random.Range(xLeft, xRight), yPos, Random.Range(zLeft,zRight)), Quaternion.identity);
            Debug.Log("Eat has been spawned!");
            i=0;
        }else{
            i++;
        }
    }
}
