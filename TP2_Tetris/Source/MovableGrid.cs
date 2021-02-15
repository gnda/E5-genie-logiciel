using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid 
    {
        int col;
        int row;
        Tetromino inner;

        public MovableGrid(Tetromino inner) : this(0,0, inner)
        {
        }
        private MovableGrid(int r, int c, Tetromino inner)
        {
            this.row = r;
            this.col = c;
            this.inner = inner;
        }

        int ToInnerRow(int r)
        {
            return r - row;
        }
        int ToOuterCol(int c)
        {
            return c + col;
        }
        int ToInnerCol(int c)
        {
            return c - col;
        }
        int ToOuterRow(int r)
        {
            return r + row;
        }

        public char CellAt(int r, int c)
        {
            int inner_row = ToInnerRow(r);
            int inner_col = ToInnerCol(c);
            return inner.CellAt(inner_row, inner_col);
        }
        public bool IsAt(int r, int c)
        {
            int inner_row = ToInnerRow(r);
            int inner_col = ToInnerCol(c);
            return inner_row >= 0
                && inner_row < inner.Rows()
                && inner_col >= 0
                && inner_col < inner.Columns()
                && inner.CellAt(inner_row, inner_col) != Board.EMPTY;
        }

        
        public int Columns()
        {
            return inner.Columns();
        }
        public int Rows()
        {
            return inner.Rows();
        }
        public MovableGrid MoveTo(int r, int c)
        {
            return new MovableGrid(r, c, inner);
        }
        public MovableGrid MoveLeft()
        {
            return new MovableGrid(row, col - 1, inner);
        }

        public MovableGrid MoveRight()
        {
            return new MovableGrid(row, col + 1, inner);
        }
        public MovableGrid MoveDown()
        {
            return new MovableGrid(row+1, col, inner);
        }

        public MovableGrid RotateRight()
        {
            return new MovableGrid(row, col, inner.RotateRight());
        }

        public MovableGrid RotateLeft()
        {
            return new MovableGrid(row, col, inner.RotateLeft());
        }

        public bool OutsideBoard(Board b)
        {
            for (int row = 0; row < Rows(); row++)
            {
                for (int col = 0; col < Columns(); col++)
                {
                    if (inner.CellAt(row, col)!= Board.EMPTY)
                    {
                        int outer_row = ToOuterRow(row);
                        int outer_col = ToOuterCol(col);
                        if (outer_col < 0 || outer_col >= b.columns || outer_row < 0 || outer_row >= b.rows)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool HitsAnotherBlock(Board board)
        {
            //search on mat
            for (int row = 0; row < Rows(); row++)
            {
                for (int col = 0; col < Columns(); col++)
                {
                    if (inner.CellAt(row, col) != Board.EMPTY)
                    {
                        int outer_row = ToOuterRow(row);
                        int outer_col = ToOuterCol(col);
                        if (board.CellAt(outer_row, outer_col) != Board.EMPTY)
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
