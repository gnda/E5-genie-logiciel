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

        #region constructor

        public Board(int row_size, int column_size)
        {
            this.rows = row_size;
            this.columns = column_size;
            this.board = new char[this.rows, this.columns];
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    this.board[row, col] = EMPTY;
                }
            }
        }
        #endregion

        #region from string

        public void FromString(string blocks)
        {
            StringToMatrix stm = new StringToMatrix(blocks);
            this.board = stm.matrix;
            this.rows = stm.rows;
            this.columns = stm.columns;
        }
        #endregion

        #region drop

        public void Drop(Tetromino tetromino)
        {
            CheckIfFalling();
            int row = StartingRowOffset(tetromino);
            MovableGrid mg = new MovableGrid(tetromino);
            this.fallingBlock = mg.MoveTo(row, (this.columns / 2) - (tetromino.Columns() / 2));
        }
        #endregion

        #region falling
        public bool IsFallingBlock()
        {
            return this.fallingBlock != null;
        }
        public int StartingRowOffset(Grid form)
        {
            int to_return = 0; 
            for (int row = 0; row < form.Rows(); row++)
            {
                for (int col = 0; col < form.Columns(); col++)
                {
                    if (form.CellAt(row, col) != EMPTY)
                    {
                        row = row*-1;
                        return row;
                    }
                }
            }
            return to_return;
        }

        void CheckIfFalling()
        {
            if (IsFallingBlock())
            {
                throw new ArgumentException("other is falling");
            }
        }
        #endregion

        #region tick
        public void Tick()
        {
            MoveDown();
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
            List<int> allRows = new List<int>();
            for (int row = 0; row < this.rows; row++)
            {
                if (RowIsFull(row))
                {
                    allRows.Add(row);
                }
            }
            return allRows;
        }

        bool RowIsFull(int row)
        {
            bool to_return = true;
            for (int col = 0; col < this.columns; col++)
            {
                if (board[row, col] == EMPTY)
                {
                    to_return  = false;
                }
            }
            return to_return;
        }

        void RemoveRows(List<int> rm)
        {
            foreach (int row in rm)
                SqueezeRow(row);
        }

        void SqueezeRow(int i)
        {
            for (int row = (i - 1); row >= 0; row--)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    this.board[row + 1, col] = this.board[row, col];
                }
            }
        }
        #endregion

        #region move
        private void TryMove(MovableGrid mg)
        {
            if (!ConflictwithBoard(mg))
            {
                this.fallingBlock = mg;
            }
        }
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
            if (!this.IsFallingBlock())
            {
                return;
            }
            TryMove(fallingBlock.MoveRight());
        }
        public void MoveDown()
        {
            if (!IsFallingBlock())
            {
                return;
            }
            MovableGrid mg = this.fallingBlock.MoveDown();
            if (ConflictwithBoard(mg))
            {
                StopFallingBlock();
                RemoveFullRows();
            }
            else
            {
                this.fallingBlock = mg;
            }
        }
        #endregion

        #region rotate
        void TryRotate(MovableGrid rotated)
        {
            MovableGrid[] moves =
            {
                rotated,
                rotated.MoveLeft(),     //  wallkick  moves
                rotated.MoveRight(),
                rotated.MoveLeft().MoveLeft(),
                rotated.MoveRight().MoveRight()
            };
            foreach (MovableGrid test in moves)
            {
                if (!ConflictwithBoard(test))
                {
                    this.fallingBlock = test;
                    return;
                }
            }
        }
        public void RotateRight()
        {
            if (!this.IsFallingBlock())
            {
                return;
            }
            TryRotate(this.fallingBlock.RotateRight());
        }

        public void RotateLeft()
        {
            if (!this.IsFallingBlock())
            {
                return;
            }
            TryRotate(this.fallingBlock.RotateLeft());
        }
        #endregion

        #region conflit
        bool ConflictwithBoard(MovableGrid rotated)
        {
            return rotated.OutsideBoard(this) || rotated.HitsAnotherBlock(this);
        }
        #endregion

        #region tostring
        public override String ToString()
        {
            String to_return = "";
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    to_return += StatusAt(row, col);
                }
                to_return += "\n";
            }
            return to_return;
        }
        #endregion

        #region status At
        private char StatusAt(int row, int col)
        {

            if (this.fallingBlock != null && this.fallingBlock.IsAt(row, col))
            {
                //Console.WriteLine("this.fallingBlock.getType(): {0}", CellAt(row, col));
                return this.fallingBlock.CellAt(row, col);
            }
            else
            {
                //Console.WriteLine("this.block[row, col]: {0}", this.board[row, col]);
                return this.board[row, col];
            }
        }
        #endregion

        #region cellule
        public char cellule(int row, int col) {
            return this.board[row, col];
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
