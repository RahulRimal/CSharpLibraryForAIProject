using System;
using System.Collections.Generic;

class Matrix
{

    Random random = new Random();

    public int rows;
    public int cols;
    public List<float[]> data = new List<float[]>();

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        for(int i = 0; i < rows; i++)
        {
            data.Add(new float[cols]);
            for(int j = 0; j < cols; j++)
            {
                data[i][j] = 0f;
            }
        }
    }


    public void randomize()
    {
        for(int i = 0; i < this.rows; i++)
        {
            data.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                data[i][j] = random.Next(-1,1);
            }
        }
    }

    public void multiply(float n)
    {
        for(int i = 0; i < rows; i++)
        {
            data.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                data[i][j] *= n;
            }
        }
    }

    public static Matrix multiply(Matrix a, Matrix b)
    {
        if(a.cols != b.rows)
        {
            Console.WriteLine(" The dimensions must match !! ");
            return null;
        }
        else
        {
            Matrix result = new Matrix(a.rows, b.cols);

            for(int i = 0; i < result.rows; i++)
            {
                for(int j = 0; j < result.cols; j++)
                {
                    float sum = 0;
                    
                    for(int k = 0; k < a.cols; k++)
                    {
                        sum += a.data[i][k] * b.data[k][j];
                    }
                    result.data[i][j] = sum;
                }
            }
            return result;

        }
    }

    public void add(float n)
    {
        for(int i = 0; i < this.rows; i++)
        {
            data.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                data[i][j] += n;
            }
        }
    }

    public void add(Matrix mat)
    {
        for(int i = 0; i < this.rows; i++)
        {
            data.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                data[i][j] += mat.data[i][j];
            }
        }
    }


    public Matrix transpose()
    {
        Matrix result = new Matrix(this.cols, this.rows);
        for(int i = 0; i < this.rows; i++)
        {
            data.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                result.data[j][i] = this.data[i][j];
            }
        }
        
        return result;
    }


    public static Matrix fromArray(float[] arr)
    {
        Matrix m = new Matrix(arr.Length, 1);
        for(int i = 0; i < arr.Length; i++)
        {
            m.data[i][0] = arr[i];
        }
        return m;
    }

    public static float[] toArray(Matrix mat)
    {
        List<float> arra = new List<float>(); 
        for(int i = 0; i < mat.rows; i++)
        {
            for(int j = 0; j < mat.cols; j++)
            {
                arra.Add(mat.data[i][j]);
            }
        }
        return arra.ToArray();   
    }

    public float sigmoid(float x)
    {
        double num = (double) x;
        double res = 1/( 1 + Math.Exp(-num));
        return (float) res;
    }


    public void map(string name)
    {
        if(name == "sigmoid")
        {
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.cols; j++)
                {
                    float val = this.data[i][j];

                    this.data[i][j] = sigmoid(val);
                }
            }
        }
    }
    
}