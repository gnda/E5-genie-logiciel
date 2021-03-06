﻿using System;
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

        #region constructor
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
        #endregion

        #region :Grid
        public bool IsAt(int row, int col)
        {
            return (row == this.rows) && (col == this.columns);
        }

        public char CellAt(int row, int col)
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
        #endregion
    }
}
