using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;

public class BaseScript : MonoBehaviour
{
    public GameObject MyCube;
    private string[] NameBots = new string[300];
    private Dictionary<string, Net> BotsCommands = new Dictionary<string, Net>();
    private int index;
    void Start()
    {
        index = 0;
        
    }
    // Здесь идет проход по всем ботам и выполнение команд
    void Commands_start(){
        for (int i=0;i<index;i++){
            float random = 0.8f;
            
            float[,] random_get = new float[2,2];
            random_get[0,0] = random;
            random_get[1,0] = random;
            float[,] BotReturn = BotsCommands[NameBots[i]].Think(random_get);
            MyCube = GameObject.Find(NameBots[i]);
            Debug.Log("thin result bot "+NameBots[i]+ " "+ BotReturn[0,0]);
            float bot_command = BotReturn[0,0];
            if (bot_command < 0.5f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z + 0.01f);

            }
            if (bot_command  > 0.5f){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z - 0.01f);

            }
            // if (bot_command  == 2f){
            //     MyCube.transform.position = new Vector3(MyCube.transform.position.x-0.01f,MyCube.transform.position.y,MyCube.transform.position.z);

            // }
            // if (bot_command  == 3f){
            //     MyCube.transform.position = new Vector3(MyCube.transform.position.x+0.01f,MyCube.transform.position.y,MyCube.transform.position.z);

            // }
            // else{
            //     MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y+0.01f,MyCube.transform.position.z);
            // }
            

        }
    }
    
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.N)){
            MyCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            MyCube.AddComponent<Rigidbody>();
            MyCube.transform.position = new Vector3(124.94f, 60.39f, 181.72f);
            MyCube.name = "Bot"+index.ToString();
            NameBots[index] = "Bot"+index.ToString();
            Net NetBot = new Net();
            NetBot.CreateNet(2,10,2);
            BotsCommands.Add("Bot"+index.ToString(),NetBot);
            index++;
        }
        Commands_start();
    }
}
