using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        readonly int rows;
        readonly int columns;
        bool isFallingBlock;
        char[,] mat;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.mat = new char[this.rows,this.columns];
            for(int row = 0; row < this.rows; row++)
            {
                for(int col = 0; col < this.columns; col++)
                {
                    this.mat[col, row] = '.';
                }
            }
            this.isFallingBlock = false;
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    s += mat[col, row];
                }
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock()
        {
            return isFallingBlock;
        }

        public void Drop(Block block)
        {
            this.isFallingBlock = true;
            this.mat[0, 1] = block.getChar();
        }

        public void Tick()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (mat[col, row] != '.')
                    {
                        char c = mat[col, row];
                        mat[col, row] = '.';
                        mat[col, row + 1] = c;
                        break;
                    }
                }
            }
        }
    }
}
