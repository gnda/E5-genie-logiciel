using System.Text;
using Source;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace Source
{
    public class StringToMatrix{
        public char[,] blocks;
        public int rows;
        public int columns;
        //private string shape;
        public StringToMatrix(string shape)
        {

            //this.shape = shape;
            string[] block = shape.Split(new char[] { '\n'}, System.StringSplitOptions.RemoveEmptyEntries); //caster
            this.rows = block.Length;
            this.columns = block[0].Length;
            this.blocks = new char[this.rows, this.columns]; 
            for (int i=0; i< this.rows; i++)
            {
                char[] row = block[i].ToCharArray();
                if (row.Length != this.columns)
                    throw new System.Exception("Not same size");
                for(int j = 0; j< this.columns; j++)
                {
                    this.blocks[i, j] = row[j];
                }
            }
        }

        public static string Inverse(char[,] blocks, int rows, int columns)
        {
            string to_return = "";
            //while blocks
            for(int row =0; row < rows; row++)
            {
                for (int column = 0 ; column < columns; column++)
                {
                    to_return += blocks[row, column];
                }
                to_return += '\n';
            }
            return to_return;
        }

    }

    public class Piece : Grid
    {
        int rows;
        int columns;
        char[,] blocks;

        public Piece(string shape)
        {
            StringToMatrix s2m = new StringToMatrix(shape);
            this.blocks = s2m.blocks;
            this.rows = s2m.rows;
            this.columns = s2m.columns;
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