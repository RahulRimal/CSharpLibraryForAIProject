using System;

class Program {
    static void Main(string[] args) {
        // Console.WriteLine("Hello, world!");

        NeuralNetwork nn = new NeuralNetwork(2, 2, 2);
        float[] inputs = {1f, 0};
        float[] targets = {1f, 0};

        nn.train(inputs, targets);
        

    }
}