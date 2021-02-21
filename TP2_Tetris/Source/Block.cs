using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Block : Grid 
    {
        public int columns { get; private set; }
        public int rows { get; private set; }
        char[,] block;

        public Block(char type) : this(0, 0)
        {
        }

        public Block(Tetromino grid)
        {
            this.rows = grid.Rows();
            this.columns = grid.Columns();
            this.block = new char[this.rows, this.columns];
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    this.block[row, col] = grid.cellule(row, col);
                }
            }
        }
        public Block(int row, int column )
        {
            this.rows = row;
            this.columns = column;
        }


        public Block MoveTo(int row, int column) {         
            return new Block(row, column);
        }

        public Block MoveDown()
        {
            int row = this.rows + 1; 
            return new Block(row, this.columns);
        }

        public bool IsAt(int row, int col)
        {
            return (row == this.rows) && (col == this.columns);
        }

        public char cellule(int row, int col)
        {
           return block[row,col];
        }
        public int Columns()
        {
            return this.columns;
        }
        public int Rows()
        {
            return this.rows;
        }

        public  Block MoveLeft()
        {
            throw new NotImplementedException();
        }

        public  Block MoveRight()
        {
            
            throw new NotImplementedException();
        }

        public Block RotateRight()
        {
            throw new NotImplementedException();
        }

        public Block RotateLeft()
        {
            throw new NotImplementedException();
        }



        bool OutsideBoard(Board board)
        {
            for (int row = 0; row < Rows(); row++)
            {
                for (int col = 0; col < Columns(); col++)
                {
                    if (inner.CellAt(row, col)!= Board.EMPTY)
                    {
                        int outer_row = ToOuterRow(row);
                        int outer_col = ToOuterCol(col);
                        if (outer_col < 0 || outer_col >= board.columns || 
                            outer_row < 0 || outer_row >= board.rows)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
