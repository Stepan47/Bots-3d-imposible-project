using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Network;
using System;
using System.IO;

public class BaseScript : MonoBehaviour
{
    public GameObject MyCube;
    private string[] NameBots = new string[300];
    private Dictionary<string, Net> BotsCommands = new Dictionary<string, Net>();
    private int index;
    private int ActivNeuron;//здесь записывается номер по счету какой нейрон активирован
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
            ActivNeuron = 0;
            for (int IAN=1;IAN<Outputs.GetLength(0);IAN++){//"IAN" переводится как "index activ neuron"
                if (Outputs[IAN,0] > Outputs[IAN-1,0]){
                    ActivNeuron = IAN;

                }
            }

            if (ActivNeuron == 0){//если активирован нейрон под номером 0 то от z отнимается 0.03f
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z - 0.03f);

            }
            if (ActivNeuron == 1){//если активирован нейрон под номером 1 то к z прибовляется 0.03f
                MyCube.transform.position = new Vector3(MyCube.transform.position.x,MyCube.transform.position.y,MyCube.transform.position.z + 0.03f);

            }
            if (ActivNeuron == 2){//если активирован нейрон под номером 2 то от x отнимается 0.03f
                MyCube.transform.position = new Vector3(MyCube.transform.position.x-0.03f,MyCube.transform.position.y,MyCube.transform.position.z);

            }
            if (ActivNeuron == 3){//если активирован нейрон под номером 3 то к z прибовляется 0.03f
                MyCube.transform.position = new Vector3(MyCube.transform.position.x+0.03f,MyCube.transform.position.y,MyCube.transform.position.z);

            }
            //работа с энергией
            BotsCommands[NameBots[i]].MinusEnegry(300);
            if (BotsCommands[NameBots[i]].GetEnergy() <= 0 ){
                for (int delete_name=0;delete_name<NameBots.GetLength(0);delete_name++){
                    if (NameBots[delete_name] == MyCube.name){
                    	//Array.Clear(NameBots,delete_name,0);
                        //Destroy(MyCube);// и наконец удаляем бота
                        continue;
                    }

                }
                
                

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
