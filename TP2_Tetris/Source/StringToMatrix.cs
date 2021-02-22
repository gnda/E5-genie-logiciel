using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source;
using System.Windows.Markup;

namespace Source
{
    public class StringToMatrix
    {
        public char[,] matrix;
        public int columns { get; private set; }
        public int rows { get; private set; }
        //private string shape;

        #region constructor
        public StringToMatrix(string shape)
        {
            //this.shape = shape;
            string[] block = shape.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries); //cat
            this.rows = block.Length;
            this.columns = block[0].Length;
            this.matrix = new char[this.rows, this.columns];
            
            char[] row = null;

            for (int i = 0; i < this.rows; i++)
            {
                row = block[i].ToCharArray();
                if (row.Length != this.columns)
                    throw new System.Exception("Not same size");
                for (int j = 0; j < this.columns; j++)
                {
                    this.matrix[i, j] = row[j];
                }
            }
        }
        #endregion

        #region inverse
        public static string Inverse(char[,] param_matrix, int row_size, int column_size)
        {
            string to_return = "";
            //while blocks
            for (int row = 0; row < row_size; row++)
            {
                for (int col = 0; col < column_size; col++)
                {
                    to_return += param_matrix[row, col];
                }
                to_return += '\n';
            }
            return to_return;
        }

        #endregion

    }
}
