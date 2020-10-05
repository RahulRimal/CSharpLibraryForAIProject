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
                data[i][j] = random.Next(20);
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


    // public void map(func)
    // {
    //     for(int i = 0; i < this.rows; i++)
    //     {
    //         data.Add(new float[this.cols]);
    //         for(int j = 0; j < this.cols; j++)
    //         {
    //             float val = this.data[j][i];
    //             this.data[j][i] = func(val);
    //         }
    //     }
    // }
    
}