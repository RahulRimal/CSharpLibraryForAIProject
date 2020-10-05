using System.Collections.Generic;

class Matrix
{
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
    
}