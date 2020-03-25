using System;

namespace Network
{
    class Net{
        public static float[,] N0;
        public static float[,] N1;
        public static float[,] N2;
        public static float[,] W0;
        public static float[,] W1;
        public void CreateNet(int v0, int v1, int v2){
            Random RFW = new Random();
            Network.Net.N0 = new float[v0,2];
            Network.Net.N1 = new float[v1,2];
            Network.Net.N2 = new float[v2,2];
            Network.Net.W0 = new float[Network.Net.N0.GetLength(0),Network.Net.N1.GetLength(0)];
            Network.Net.W1 = new float[Network.Net.N1.GetLength(0),Network.Net.N2.GetLength(0)];
            for (int i=0;i<Network.Net.W0.GetLength(0);i++){
                for(int j=0;j<Network.Net.W0.GetLength(1);j++){
                    Network.Net.W0[i,j] = RFW.Next(0,2);
                }
            }
            for (int i=0;i<Network.Net.W1.GetLength(0);i++){
                for(int j=0;j<Network.Net.W1.GetLength(1);j++){
                    Network.Net.W1[i,j] = RFW.Next(0,2);

                }
            }
        }
        public float[,] Think(float[,] N0T){
            Network.Net.N1 = progon(N0T,Network.Net.N0,Network.Net.W0);//Всего два прогона потому что первый слой входной
            Network.Net.N2 = progon(Network.Net.N1,Network.Net.N2,Network.Net.W1);
            return Network.Net.N1;
        }
        private float[,] progon(float[,] Li, float[,] Lo, float[,] W)
        {
            int VI = Li.GetLength(0);
            int VO = Lo.GetLength(0);
            int x = 0;
            int y = 0;
            while (x < VO){
                y = 0;
                Lo[x,0] = 0.0f;
                while (y < VI){
                    Lo[x,0] = Lo[x,0] + Li[y,0] * W[x,y];
                    y++;
                } 
                if (Lo[x,0] > 1){
                    Lo[x,0] = 1f + 0.1f*(Lo[x,0] - 1f);

                }
                if (Lo[x,0] < 0){
                    Lo[x,0] = Lo[x,0] * 0.1f;
                } 
                x++;

            }
            return Lo;

        }
        public float[,] OutFindError(float[,] IDL, float[,] N){
            int V = IDL.GetLength(0);
            int x = 0;
            while (x < V){
                N[x,1] = IDL[x,0] - N[x,0];
                if (N[x,0] > 1 || N[x,0] < 0){
                    N[x,1] = N[x,1] * 0.1f;
                }
                x++;
            }
            return N;
        }
        public float[,] FindError(float[,] Li, float[,] Lo, float[,] W){
            int VI = W.GetLength(1);
            int VO = W.GetLength(0);
            int x = 0;
            int y = 0;
            while (x < VI){
                y = 0;
                Li[x,1] = 0.0f;
                while (y < VO){
                    Li[x,1] = Li[x,1] + W[y,x] * Lo[y,1];
                    if (Li[x,0] > 1 || Li[x,0] < 0){
                        Li[x,1] = Li[x,1] * 0.1f;
                    }
                    y++;
                }
                x++;
            }
            return Li;
        }
        public float[,] SaveError(float[,] Li, float[,] Lo, float[,] W, float k){
            int VI = W.GetLength(1);
            int VO = W.GetLength(0);
            int x = 0;
            int y = 0;
            while (x < VO){
                y = 0;
                while (y < VI){
                    W[x,y] = W[x,y] + k * Lo[x,1] * Li[y,0];
                    y++;
                }
                x++;
            }
            return W;
        }


    }
}
