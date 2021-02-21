using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid 
    {
        public int columns { get; private set; }
        public int rows { get; private set; }
        Tetromino tetromino;

        #region constructor
        public MovableGrid(Tetromino tetromino) : this(0,0, tetromino)
        {
        }
        private MovableGrid(int moverow, int movecol, Tetromino tetromino)
        {
            this.rows = moverow;
            this.columns = movecol;
            this.tetromino = tetromino;
        }

        #endregion

        #region grid
        public char CellAt(int row, int col)
        {
            int moverow = row - this.rows;
            int movecol = col - this.columns;
            return this.tetromino.CellAt(moverow, movecol);
        }
        public bool IsAt(int row, int col)
        {
            int moverow = row - this.rows;
            int movecol = col-this.columns;
            return (moverow >= 0)
                && (movecol >= 0)
                && (moverow < this.tetromino.Rows())
                && (movecol < this.tetromino.Columns())
                && (this.tetromino.CellAt(moverow, movecol) != Board.EMPTY);
        }

        
        public int Columns()
        {
            return this.tetromino.Columns();
        }
        public int Rows()
        {
            return this.tetromino.Rows();
        }
        #endregion

        #region movable
        public MovableGrid MoveTo(int moverow, int movecol)
        {
            return new MovableGrid(moverow, movecol, this.tetromino);
        }
        public MovableGrid MoveLeft()
        {
            return new MovableGrid(this.rows, (this.columns - 1), this.tetromino);
        }

        public MovableGrid MoveRight()
        {
            return new MovableGrid(this.rows, (this.columns + 1), this.tetromino);
        }
        public MovableGrid MoveDown()
        {
            return new MovableGrid(this.rows + 1, this.columns, this.tetromino);
        }
        #endregion

        #region rotate

        public MovableGrid RotateRight()
        {
            return new MovableGrid(this.rows, this.columns, this.tetromino.RotateRight());
        }

        public MovableGrid RotateLeft()
        {
            return new MovableGrid(this.rows, this.columns, this.tetromino.RotateLeft());
        }
        #endregion

        #region is Outside the board 
        public bool OutsideBoard(Board board)
        {
            bool to_return = false;
            for (int row = 0; row < Rows(); row++)
            {
                for (int col = 0; col < Columns(); col++)
                {
                    if (tetromino.CellAt(row, col)!= Board.EMPTY)
                    {
                        int moverow = row+this.rows;
                        int movecol = col+this.columns;
                        if ( 
                            (movecol < 0) || (movecol >= board.columns) 
                            || (moverow < 0) || (moverow >= board.rows)
                            )
                        {
                            return true;
                        }
                    }
                }
            }
            return to_return;
        }
        #endregion 

        #region hits other block
        public bool HitsAnotherBlock(Board board)
        {
            for (int row = 0; row < Rows(); row++)
            {
                for (int col = 0; col < Columns(); col++)
                {
                    if (this.tetromino.CellAt(row, col) != Board.EMPTY)
                    {
                        int moverow = row+this.rows;
                        int movecol = col+ this.columns;
                        if (board.cellule(moverow, movecol) != Board.EMPTY)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
