using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public GameObject MyCube;
    private string[] NameBots = new string[300];
    private Dictionary<string, int[]> BotsCommands = new Dictionary<string, int[]>(300);
    private int index;
    private int index_command = 0;
    void Start()
    {
    	index = 0;
        
    }
    // Здесь идет проход по всем ботам и выполнение команд
    void Commands_start(){
        for (int i=0;i<index;i++){
            float bot_command = BotsCommands[NameBots[i]][index_command];
            MyCube = GameObject.Find(NameBots[i]);
            if (bot_command == 0f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z + 0.01f);

            }
            if (bot_command  == 1f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z - 0.01f);

            }
            if (bot_command  == 2f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x-0.01f,MyCube.transform.position.y,MyCube.transform.position.z);

            }
            if (bot_command  == 3f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x+0.01f,MyCube.transform.position.y,MyCube.transform.position.z);

            }
            else{
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y+0.01f,MyCube.transform.position.z);
            }
            

        }
        if (index_command >= 1){
            index_command = 0;
        }
        index_command++;
    }
    
    void Update() 
    {
    	if (Input.GetKeyDown(KeyCode.N)){
    		MyCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    		MyCube.AddComponent<Rigidbody>();
    		MyCube.transform.position = new Vector3(200f, 25f, 130f);
    		MyCube.name = "Bot"+index.ToString();
    		NameBots[index] = "Bot"+index.ToString();
            int[] list = new int[2];
            for (int i=0;i<list.GetLength(0);i++){
                list[i] = Random.Range(0,4);
            }
            BotsCommands.Add("Bot"+index.ToString(),list);
    		index++;
    	}
        Commands_start();
    }
}
