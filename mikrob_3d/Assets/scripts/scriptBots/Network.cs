using System;

namespace Network
{
    class Net{
        private float[,] N0;
        private float[,] N1;
        private float[,] N2;
        private float[,] W0;
        private float[,] W1;
        public Net(int v0, int v1, int v2){
            Random RFW = new Random();
            this.N0 = new float[v0,2];
            this.N1 = new float[v1,2];
            this.N2 = new float[v2,2];
            this.W0 = new float[this.N0.GetLength(0),this.N1.GetLength(0)];
            this.W1 = new float[this.N1.GetLength(0),this.N2.GetLength(0)];
            for (int i=0;i<this.W0.GetLength(0);i++){
                for(int j=0;j<this.W0.GetLength(1);j++){
                    this.W0[i,j] = RFW.Next(200,1000) / 2054f - 0.3f;
                }
            }
            for (int i=0;i<this.W1.GetLength(0);i++){
                for(int j=0;j<this.W1.GetLength(1);j++){
                    this.W1[i,j] = RFW.Next(0,2);

                }
            }
        }
        public float[,] Think(float[,] N0T){
            this.N0 = N0T;
            this.N1 = progon(this.N0,this.N1,this.W0);//Всего два прогона потому что первый слой входной
            this.N2 = progon(this.N1,this.N2,this.W1);
            return this.N2;
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
                    Lo[x,0] = Lo[x,0] + Li[y,0] * W[y,x];
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
