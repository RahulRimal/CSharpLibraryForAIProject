using System;

class NeuralNetwork
{
    public int input_nodes;
    public int hidden_nodes;
    public int output_nodes;
    Matrix weights_ih;
    Matrix weights_ho;
    Matrix bias_h;
    Matrix bias_o;


    public NeuralNetwork(int input_nodes, int hidden_nodes, int output_nodes)
    {
        this.input_nodes = input_nodes;
        this.hidden_nodes = hidden_nodes;
        this.output_nodes = output_nodes;

        this.weights_ih = new Matrix(this.hidden_nodes, this.input_nodes);
        this.weights_ho = new Matrix(this.output_nodes, this.hidden_nodes);
        weights_ih.randomize();
        weights_ho.randomize();

        this.bias_h = new Matrix(this.hidden_nodes, 1);
        this.bias_o = new Matrix(this.output_nodes, 1);
        this.bias_h.randomize();
        this.bias_o.randomize();
    }


    public float[] feedForward(float[] input_array)
    {
        Matrix inputs = Matrix.fromArray(input_array);
        Matrix hidden = Matrix.multiply(this.weights_ih, inputs);
        hidden.add(this.bias_h);

        hidden.map("sigmoid");

        Matrix output = Matrix.multiply(this.weights_ho, hidden);
        output.add(this.bias_o);
        
        output.map("sigmoid");

        float[] outputResult = Matrix.toArray(output);

        return outputResult;

    }

    public void train(float[] inputs, float[] target)
    {
      // float[] output = this.feedForward(inputs);

      Matrix inputss = Matrix.fromArray(inputs);
      Matrix hidden = Matrix.multiply(this.weights_ih, inputss);
      hidden.add(this.bias_h);

      hidden.map("sigmoid");

      Matrix outputs = Matrix.multiply(this.weights_ho, hidden);
      outputs.add(this.bias_o);
        
      outputs.map("sigmoid");

      Matrix targets = Matrix.fromArray(target);


      // Calculating the error (for back prop)

      Matrix outputErrors = Matrix.subtract(targets, outputs);

      // Calculating hidden layer errors
      Matrix weights_ho_transpose = Matrix.transpose(this.weights_ho);

      Matrix hidden_errors = Matrix.multiply(weights_ho_transpose, outputErrors);

      Console.WriteLine(outputs.data[0][0]);
      Console.WriteLine(targets.data[0][0]);
      Console.WriteLine(outputErrors.data[0][0]);

    }

}