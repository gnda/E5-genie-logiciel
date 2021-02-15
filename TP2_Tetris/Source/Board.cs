using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{

    public class Board
    {
        public static readonly char EMPTY = '.';
        MovableGrid fallingBlock;
        char[,] board;

        public int rows { get; private set; }
        public int columns { get; private set; }

        #region init

        public Board(int row, int column)
        {
            this.rows = row;
            this.columns = column;
            this.board = new char[row, column];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    this.board[r, c] = EMPTY;
                }
            }
        }

        public void FromString(string blocks)
        {
            StringToMatrix stm = new StringToMatrix(blocks);
            this.board = stm.blocks;
            this.rows = stm.rows;
            this.columns = stm.columns;
        }
        #endregion

        #region drop
        public void Drop(Tetromino shape)
        {
            CheckIfFalling();
            int r = StartingRowOffset(shape);
            MovableGrid b = new MovableGrid(shape);
            fallingBlock = b.MoveTo(r, (this.columns / 2) - (shape.Columns() / 2));
        }

        public int StartingRowOffset(Grid shape)
        {
            for (int r = 0; r < shape.Rows(); r++)
            {
                for (int c = 0; c < shape.Columns(); c++)
                {
                    if (shape.CellAt(r, c) != EMPTY)
                    {
                        return -r;
                    }
                }
            }
            return 0;
        }

        void CheckIfFalling()
        {
            if (IsFallingBlock())
            {
                throw new ArgumentException("Another block is already falling");
            }
        }

        public bool IsFallingBlock()
        {
            return this.fallingBlock != null;
        }
        #endregion

        #region tick
        public void Tick()
        {
            MoveDown();
        }

        public void MoveDown()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            MovableGrid test = this.fallingBlock.MoveDown();
            if (ConflictwithBoard(test))
            {
                StopFallingBlock();
                RemoveFullRows();
            }
            else
            {
                fallingBlock = test;
            }
        }

        void StopFallingBlock()
        {
            CopyToBoard(this.fallingBlock);
            this.fallingBlock = null;
        }

        void CopyToBoard(MovableGrid block)
        {
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    if (block.IsAt(row, col))
                    {
                        this.board[row, col] = block.CellAt(row, col);
                    }
                }
            }
        }

        #endregion

        #region removing_rows

        void RemoveFullRows()
        {
            RemoveRows(FindFullRows());
        }

        List<int> FindFullRows()
        {
            List<int> fullRows = new List<int>();
            for (int r = 0; r < rows; r++)
            {
                if (RowIsFull(r))
                {
                    fullRows.Add(r);
                }
            }
            return fullRows;
        }

        bool RowIsFull(int row)
        {
            for (int col = 0; col < columns; col++)
            {
                if (board[row, col] == EMPTY)
                {
                    return false;
                }
            }
            return true;
        }

        void RemoveRows(List<int> rowsToRemove)
        {
            foreach (int idx in rowsToRemove)
                SqueezeRow(idx);
        }

        void SqueezeRow(int idx)
        {
            for (int r = idx - 1; r >= 0; r--)
            {
                for (int c = 0; c < this.columns; c++)
                {
                    board[r + 1, c] = board[r, c];
                }
            }
        }
        #endregion

        #region move
        public void MoveLeft()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            TryMove(fallingBlock.MoveLeft());
        }

        public void MoveRight()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            TryMove(fallingBlock.MoveRight());
        }

        private void TryMove(MovableGrid p)
        {
            if (!ConflictwithBoard(p))
            {
                fallingBlock = p;
            }
        }
        #endregion

        #region rotate
        public void RotateRight()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            TryRotate(this.fallingBlock.RotateRight());
        }

        public void RotateLeft()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            TryRotate(this.fallingBlock.RotateLeft());
        }

        void TryRotate(MovableGrid b)
        {
            MovableGrid[] moves =
            {
                b,
                b.MoveLeft(),
                b.MoveRight(),
                b.MoveLeft().MoveLeft(),
                b.MoveRight().MoveRight() /**,**/
            };
            foreach (MovableGrid move in moves)
            {
                if (!ConflictwithBoard(move))
                {
                    fallingBlock = move;
                    return;
                }
            }
        }
        #endregion

        #region conflit

        bool ConflictwithBoard(MovableGrid block)
        {
            return block.OutsideBoard(this) || block.HitsAnotherBlock(this);
        }

        public char CellAt(int row, int col)
        {
            return board[row, col];
        }

        #endregion

        #region status

        public override String ToString()
        {
            String value = "";
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    value += StatusAt(row, col);
                }
                value += "\n";
            }
            return value;
        }

        private char StatusAt(int row, int column)
        {

            if (this.fallingBlock != null && this.fallingBlock.IsAt(row, column))
            {
                //Console.WriteLine("this.fallingBlock.getType(): {0}", CellAt(row, column));
                return this.fallingBlock.CellAt(row, column);
            }
            else
            {
                //Console.WriteLine("this.block[row, column]: {0}", this.board[row, column]);
                return CellAt(row, column);
            }
        }

        #endregion

        /**
        bool OutsideBoard(MovableGrid block)
        {
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    if (block.IsAt(row, col))
                    {
                        board[row, col] = block.CellAt(row, col);
                    }
                }
            }
            return block.Rows() >= this.rows;
        }
        bool HitsAnotherBlock(MovableGrid block)
        {
            //search on mat
            return this.board[block.Rows(), block.Columns()] != EMPTY;
        }
        **/

    }
}
