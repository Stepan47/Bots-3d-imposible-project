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
    private string bot_command;//здесь записывается команда типа "ход" "есть" и.т.д...
    void Start()
    {
        index = 0;
        
    }
    // Здесь идет проход по всем ботам и выполнение команд
    void Commands_start(){
        for (int i=0;i<index;i++){
            MyCube = GameObject.Find(NameBots[i]);
            float[,] Inputs = new float[3,2];//здесь входные данные для нейросети каждого бота
            Inputs[0,0] = MyCube.transform.position.x;//x данного куба
            Inputs[1,0] = MyCube.transform.position.y;//y данного куба
            Inputs[2,0] = MyCube.transform.position.z;//z данного куба
            float[,] Outputs = BotsCommands[NameBots[i]].Think(Inputs);//в функции think получаем ответ
                                                                         //от нейросети
            //Это проверка какой нейрон активен больше всех
            //надо будет как-то сделать по лучше, но пока тест :)
            if (Outputs[0,0]>Outputs[1,0]&&Outputs[0,0]>Outputs[2,0]&&Outputs[0,0] > Outputs[3,0]){
                bot_command = "-z";
            }
            if (Outputs[1,0]>Outputs[0,0]&&Outputs[1,0]>Outputs[2,0]&&Outputs[1,0] > Outputs[3,0]){
                bot_command = "+z";
            }
            if (Outputs[2,0]>Outputs[0,0]&&Outputs[2,0]>Outputs[1,0]&&Outputs[2,0] > Outputs[3,0]){
                bot_command = "-x";
            }
            if (Outputs[3,0]>Outputs[0,0]&&Outputs[3,0]>Outputs[1,0]&&Outputs[3,0] > Outputs[2,0]){
                bot_command = "+x";
            }

            if (bot_command == "-z"){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z - 0.03f);

            }
            if (bot_command == "+z"){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z + 0.03f);

            }
            if (bot_command == "-x"){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x-0.03f,MyCube.transform.position.y,MyCube.transform.position.z);

            }
            if (bot_command == "+x"){
                MyCube.transform.position = new Vector3(MyCube.transform.position.x+0.03f,MyCube.transform.position.y,MyCube.transform.position.z);

            }

            

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
            Net NetBot = new Net(3,10,4);
            BotsCommands.Add("Bot"+index.ToString(),NetBot);
            index++;
        }
        Commands_start();
    }
}
