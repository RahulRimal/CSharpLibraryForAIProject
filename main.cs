using System;

class Program {

    // float sigmoid(float x)
    //     {
    //         double num = (double) x;
    //         double res = 1/( 1 + Math.Exp(-num));
    //         return (float) res;
    //     }

    static void Main(string[] args) {
        // Console.WriteLine("Hello, world!");

        
        NeuralNetwork nn = new NeuralNetwork(2, 4, 1);
        // float[] inputs = {1f, 0};
        // float[] targets = {1f};

        // float[,] trainingSet = {{1f, 0, 1f},
        //                         {0, 1f, 1f},
        //                         {1f, 1f, 0},
        //                         {0, 0, 0}
        //                         };
        float[] input1 = {1f, 0};
        float[] input2 = {0, 1f};
        float[] input3 = {1f, 1f};
        float[] input4 = {0, 0};
        float[]target1 = {1f};
        float[]target2 = {1f};
        float[]target3 = {0};
        float[]target4 = {0};
        // float[] targets = {1f, 1f, 0, 0};

        Random rand = new Random();

        for(int i = 0; i < 50000; i++)
        {

          int randNum = rand.Next(1, 4);

          if(randNum == 1)
          {
            nn.train(input1, target1);
          }
          else if(randNum == 2)
          {
            nn.train(input2, target2);
          }
          else if(randNum == 3)
          {
            nn.train(input3, target3);
          }
          else if(randNum == 4)
          {
            nn.train(input4, target4);
          }

        }

        float[] testData1 = {1f, 0};
        float[] testData2 = {0, 1f};
        float[] testData3 = {0, 0};
        float[] testData4 = {1f, 1f};

        float[] guess1 = nn.feedForward(testData1);
        float[] guess2 = nn.feedForward(testData2);
        float[] guess3 = nn.feedForward(testData3);
        float[] guess4 = nn.feedForward(testData4);

        Console.WriteLine(guess1[0]);
        Console.WriteLine(guess2[0]);
        Console.WriteLine(guess3[0]);
        Console.WriteLine(guess4[0]);

        // nn.train(inputs, targets);







    }
}