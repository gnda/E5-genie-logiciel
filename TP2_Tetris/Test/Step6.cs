using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;

namespace Test
{
    [TestClass] 
    public classStep6_RemovingRowsTest
    { 
        Board board; 
        Tetromino piece;
        
        [TestInitialize]
        public voidSetUp() { 
            board = newBoard(6, 8); 
            piece = newTetromino(".X.\n" + ".X.\n" + ".X.\n"); 
        } 
    
        voidDropAndPushDown(){ 
            board.Drop(piece); 
            while (board.IsFallingBlock()) 
                board.Tick(); 
        }
    
        [TestMethod]
        public voidone_row_is_removed_and_the_empty_space_is_filled () { 
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