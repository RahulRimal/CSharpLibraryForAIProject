class Matrix
{

    Random random = new Random();

    public int rows;
    public int cols;
    public List<float[]> matrix = new List<float[]>();

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        for(int i = 0; i < rows; i++)
        {
            matrix.Add(new float[cols]);
            for(int j = 0; j < cols; j++)
            {
                matrix[i][j] = 0f;
            }
        }
    }


    public void randomize()
    {
        for(int i = 0; i < this.rows; i++)
        {
            matrix.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                matrix[i][j] = random.Next(20);
            }
        }
    }

    public void multiply(float n)
    {
        for(int i = 0; i < rows; i++)
        {
            matrix.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                matrix[i][j] *= n;
            }
        }
    }

    public Matrix multiply(Matrix b)
    {
        if(this.cols != b.rows)
        {
            Console.WriteLine(" The dimensions must match !! ");
            return null;
        }
        else
        {
            Matrix a = this;
            // List<float[]> b = mat.matrix;

            Matrix result = new Matrix(this.rows, b.cols);

            for(int i = 0; i < result.rows; i++)
            {
                for(int j = 0; j < result.cols; j++)
                {
                    float sum = 0;
                    
                    for(int k = 0; k < a.cols; k++)
                    {
                        sum += a.matrix[i][k] * b.matrix[k][j];
                    }
                    result.matrix[i][j] = sum;
                }
            }
            return result;

        }
    }

    public void add(float n)
    {
        for(int i = 0; i < this.rows; i++)
        {
            matrix.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                matrix[i][j] += n;
            }
        }
    }

    public void add(Matrix mat)
    {
        for(int i = 0; i < this.rows; i++)
        {
            matrix.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                matrix[i][j] += mat.matrix[i][j];
            }
        }
    }


    public Matrix transpose()
    {
        Matrix result = new Matrix(this.cols, this.rows);
        for(int i = 0; i < this.rows; i++)
        {
            matrix.Add(new float[this.cols]);
            for(int j = 0; j < this.cols; j++)
            {
                result.matrix[j][i] = this.matrix[i][j];
            }
        }
        
        return result;
    }
    
}