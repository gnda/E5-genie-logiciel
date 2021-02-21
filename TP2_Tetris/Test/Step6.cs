﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;

namespace Test
{
    [TestClass] 
    public class Step6
    { 
        Board board; 
        Tetromino piece;
        
        [TestInitialize]
        public void SetUp() { 
            board = new Board(6, 8); 
            piece = new Tetromino(".X.\n" + ".X.\n" + ".X.\n"); 
        } 
    
        void DropAndPushDown(){ 
            board.Drop(piece); 
            while (board.IsFallingBlock()) 
                board.Tick(); 
        }
    
        [TestMethod]
        public void one_row_is_removed_and_the_empty_space_is_filled () { 
            board.FromString(
                  "........\n" 
                + "........\n" 
                + "........\n" 
                + "AA.A.AAA\n" 
                + "BBBB.BBB\n" 
                + "CCCC.C.C\n"
                ); 
        
            DropAndPushDown(); 
            Assert.AreEqual(board.ToString(), 
                  "........\n" 
                + "........\n" 
                + "........\n" 
                + "........\n" 
                + "AA.AXAAA\n" 
                + "CCCCXC.C\n"
                );
        }
    }
}