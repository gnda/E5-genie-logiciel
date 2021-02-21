using System.Text;
using Source;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace Source
{
    public class StringToMatrix{
        public char[,] blocks;
        public int columns { get; private set; }
        public int rows { get; private set; }
        //private string shape;
        public StringToMatrix(string shape)
        {

            //this.shape = shape;
            string[] block = shape.Split(new char[] { '\n'}, System.StringSplitOptions.RemoveEmptyEntries); //cat
            this.rows = block.Length;
            this.columns = block[0].Length;
            this.blocks = new char[this.rows, this.columns];
            char[] row = null;
            for (int i=0; i< this.rows; i++)
            {
                row = block[i].ToCharArray();
                if (row.Length != this.columns)
                    throw new System.Exception("Not same size");
                for(int j = 0; j< this.columns; j++)
                {
                    this.blocks[i, j] = row[j];
                }
            }
        }

        public static string Inverse(char[,] param_blocks, int row_size, int column_size)
        {
            string to_return = "";
            //while blocks
            for(int row = 0 ; row < row_size; row++)
            {
                for (int col = 0 ; col < column_size; col++)
                {
                    to_return += param_blocks[row, col];
                }
                to_return += '\n';
            }
            return to_return;
        }

    }

    public class Piece : Grid
    {
        public int columns { get; private set; }
        public int rows { get; private set; }
        char[,] blocks;

        public Piece(string shape)
        {
            StringToMatrix s= new StringToMatrix(shape);
            this.blocks     = s.blocks;
            this.rows       = s.rows;
            this.columns    = s.columns;
        }

        public char CellAt(int row, int col)
        {
            return this.blocks[row,col];
        }
        public int Columns()
        {
            return this.columns;
        }
        public int Rows()
        {
            return this.rows;
        }
        public override string ToString()
        {
            return StringToMatrix.Inverse(this.blocks, this.Rows(), this.Columns() );
        }
    }
}