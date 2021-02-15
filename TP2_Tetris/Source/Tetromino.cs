﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Source
{
    public class Tetromino : Grid
    {
        Piece[] pieces;
        int shape;
        public static readonly Tetromino T_SHAPE = Tetromino.CreateTshape();
        public static readonly Tetromino L_SHAPE = Tetromino.CreateLshape();
        public static readonly Tetromino I_SHAPE = Tetromino.CreateIshape();
        public static readonly Tetromino J_SHAPE = Tetromino.CreateJshape();
        public static readonly Tetromino O_SHAPE = Tetromino.CreateOshape();

        public Tetromino( Piece[] pieces)
        {
            this.pieces = pieces;
            this.shape = 0;
        }
        public Tetromino(int shape, Piece[] pieces)
        {
            this.shape =  (shape + pieces.Length ) % pieces.Length;
            this.pieces = pieces;
        }
        public Tetromino(string orientation1, string orientation2,  string orientation3, string orientation4)
        : this( new Piece[] { new Piece(orientation1), new Piece(orientation2), new Piece(orientation3), new Piece(orientation4) })
        {
        }

        public Tetromino(string orientation1, string orientation2)
        : this( new Piece[] { new Piece(orientation1), new Piece(orientation2) })
        {
        }

        public Tetromino(string orientation1)
            : this( new Piece[] { new Piece(orientation1) })
        {
        }

        public static Tetromino CreateTshape()
        {
           return  
            new Tetromino(  
                            "....\n" +
                            "TTT.\n" +
                            ".T..\n"
                         ,
                            ".T..\n" +
                            "TT..\n" +
                            ".T..\n"
                         ,
                            ".T..\n" +
                            "TTT.\n" +
                            "....\n"
                        ,
                            ".T..\n" +
                            ".TT.\n" +
                            ".T..\n"
                            );
        }

        public static Tetromino CreateSshape()
        {
            Tetromino s = 
              new Tetromino(
                            "....\n" +
                            ".SS.\n" +
                            "SS..\n"
                         ,
                            "S...\n" +
                            "SS..\n" +
                            ".S..\n"
                            );
            return s;
        }

        public static Tetromino CreateIshape()
        {
            Tetromino t
              = new Tetromino(
                              "....\n" +
                              "IIII\n" +
                              "....\n" +
                              "....\n" 
                           ,
                              "..I.\n" +
                              "..I.\n" +
                              "..I.\n" +
                              "..I.\n" 
                              );
            return t;
        }

        public static Tetromino CreateZshape()
        {
            Tetromino t
              = new Tetromino(
                              "....\n" +
                              "ZZ..\n" +
                              ".ZZ.\n"
                           ,
                              "..Z.\n" +
                              ".ZZ.\n" +
                              ".Z..\n" 
                              );
            return t;
        }

        public static Tetromino CreateLshape()
        {
            Tetromino t
              = new Tetromino(
                              "....\n" +
                              "LLL.\n" +
                              "L...\n"
                           ,
                              "LL..\n" +
                              ".L..\n" +
                              ".L..\n"
                           ,
                              "....\n" +
                              "..L.\n" +
                              "LLL.\n"
                           ,
                              ".L..\n" +
                              ".L..\n" +
                              ".LL.\n"
                              );
            return t;
        }

        public static Tetromino CreateJshape()
        {
            Tetromino t
              = new Tetromino(
                              "....\n" +
                              "JJJ.\n" +
                              "..J.\n"
                           ,
                              ".J..\n" +
                              ".J..\n" +
                              "JJ..\n"
                           ,
                              "....\n" +
                              "J...\n" +
                              "JJJ.\n"
                           ,
                              ".JJ.\n" +
                              ".J..\n" +
                              ".J..\n"
                              );
            return t;
        }

        public static Tetromino CreateOshape()
        {
            Tetromino t
              = new Tetromino(
                              ".OO.\n" +
                              ".OO.\n" 
                              );
            return t;
        }



        public Tetromino RotateRight()
        {
            return new Tetromino(this.shape+1, this.pieces);
        }

        public Tetromino RotateLeft()
        {
            return new Tetromino(this.shape - 1, this.pieces);
        }

        public string ToString()
        {
            int nb = this.shape;
            return this.pieces[nb].ToString();
        }

        private Piece Current()
        {
            return pieces[shape];
        }
        public int Rows()
        {
            return Current().Rows();
        }

        public int Columns()
        {
            return Current().Columns();
        }

        public Piece laPiece()
        {
            return this.pieces[this.shape];
        }

        public char CellAt(int row, int col)
        {
            return Current().CellAt(row, col);
        }
    }
}