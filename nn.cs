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
    public float learning_rate;

    public float sigmoid(float x)
    {
      double num = (double) x;
      double res = 1/( 1 + Math.Exp(-num));
      return (float) res;
    }

    public float dsigmoid(float y)
    {
      // return sigmoid(x) * (1-sigmoid(x));
      return y*(1-y);
    }


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
        this.learning_rate = 0.1f;
    }
    public NeuralNetwork(NeuralNetwork a)
    {
      this.input_nodes = a.input_nodes;
      this.hidden_nodes = a.hidden_nodes;
      this.output_nodes = a.output_nodes;

      this.weights_ih = a.weights_ih.copy();
      this.weights_ho = a.weights_ho.copy();

      this.bias_h = a.bias_h.copy();
      this.bias_o = a.bias_o.copy();
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

    public void train(float[] input_array, float[] target_array)
    {
      // float[] output = this.feedForward(inputss);

      Matrix inputs = Matrix.fromArray(input_array);
      Matrix hidden = Matrix.multiply(this.weights_ih, inputs);
      hidden.add(this.bias_h);

      hidden.map("sigmoid");

      Matrix outputs = Matrix.multiply(this.weights_ho, hidden);
      outputs.add(this.bias_o);
        
      outputs.map("sigmoid");

      Matrix targets = Matrix.fromArray(target_array);


      // Calculating the error (for back prop)
      Matrix output_errors = Matrix.subtract(targets, outputs);

      // Calculating Gradient of hidden to output layer
      Matrix gradients = Matrix.map(outputs, "dsigmoid");
      gradients.multiply(output_errors);
      gradients.multiply(this.learning_rate);

      // Calculating hidden to output layers Deltas
      Matrix hidden_Transpose = Matrix.transpose(hidden);
      Matrix weights_ho_deltas = Matrix.multiply(gradients, hidden_Transpose);
      
      // Adjusting the weights by deltas
      this.weights_ho.add(weights_ho_deltas);
      // Adjusting the bias by deltas (which is just the gradients)
      this.bias_o.add(gradients);

      // Calculating hidden layer errors
      Matrix weights_ho_transpose = Matrix.transpose(this.weights_ho);

      Matrix hidden_errors = Matrix.multiply(weights_ho_transpose, output_errors);

      // Calculating gradients of input to hidden layer
      Matrix hidden_gradient = Matrix.map(hidden, "dsigmoid");
      hidden_gradient.multiply(hidden_errors);
      hidden_gradient.multiply(this.learning_rate);

      //  Calculating hidden to output layers Deltas

      Matrix inputs_Transpose = Matrix.transpose(inputs);
      Matrix weights_ih_deltas = Matrix.multiply(hidden_gradient, inputs_Transpose);
      
      
      this.weights_ih.add(weights_ih_deltas);

      // Adjusting the bias by deltas (which is just the gradients)
      this.bias_h.add(hidden_gradient);

      // Console.WriteLine(outputs.data[0][0]);
      // Console.WriteLine(targets.data[0][0]);
      // Console.WriteLine(output_errors.data[0][0]);

    }

    public NeuralNetwork copy()
    {
      return new NeuralNetwork(this);
    }

}

// For the birdmutation
// function mutate(x) {
//   if (random(1) < 0.1) {
//     let offset = randomGaussian() * 0.5;
//     let newx = x + offset;
//     return newx;
//   } else {
//     return x;
//   }
// }