using System.Text;
using Source;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace Source
{
    public class Piece : Grid
    {
        public int columns { get; private set; }
        public int rows { get; private set; }
        char[,] blocks;

        #region constructor
        public Piece(string shape)
        {
            StringToMatrix s= new StringToMatrix(shape);
            this.rows       = s.rows;
            this.columns    = s.columns;
            this.blocks     = s.matrix;
        }
        #endregion

        #region :Grid

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
        #endregion

        #region tostring
        public override string ToString()
        {
            return StringToMatrix.Inverse(this.blocks, this.Rows(), this.Columns() );
        }
        #endregion
    }
}