//Created by Sebastian Romero
/*

Objec­tive: Given two dimen­sional matrix, write an algo­rithm to find out the snake sequence which has the max­i­mum length. 
There could be many snake sequence in the matrix, you need to return the one with the max­i­mum length. 
Travel is allowed only in two direc­tions, either go right OR go down.

What is snake sequence: Snake sequence can be made if num­ber in adja­cent right cell or num­ber in the adja­cent down cell is 
either +1 or –1 from the num­ber in the cur­rent cell.

INPUT:

1 2 1 2
7 7 2 5
6 4 3 4
1 2 2 5

Snakes sequences:
1-2-1-2
5-4-5
4-3-4-5
1-2
1-2-1-2-3-4-5

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] arrA  = new int[,] { {1,2,1,2}, {7,7,2,5},{6,4,3,4},{1,2,2,5} };
            getMaxSnakeSequence( arrA );
        }

        public static int getMaxSnakeSequenceDP( int[,] matrix ) {

	        int rows = matrix.GetLength(0);
	        int cols = matrix.GetLength(1);
	        int maxLenth =1;
	        int maxRow = 0;
	        int maxCol = 0;

	        //create result matrix
	        int[,] result = new int[rows,cols];

	        //if no sequence is found then every cell itself is a sequence of length 1
	        for (int i=0; i<rows ; i++) {
	            for (int j = 0; j<cols ; j++) {
	                result[i,j] = 1;
	            }
	        }

	        for ( int i=0; i<rows ; i++ ) {
	            for ( int j=0; j<cols ; j++ ) {
	                if( i!=0 || j!=0 ) {
	                    //check from left
	                    if( i>0 && Math.Abs( matrix[i,j]-matrix[i-1,j] ) == 1 ) {
	                        result[i,j] = Math.Max(result[i,j],
	                                result[i-1,j]+1);
	                        if( maxLenth < result[i,j] ) {
	                            maxLenth = result[i,j];
	                            maxRow = i;
	                            maxCol = j;
	                        }
	                    }

	                    //check from top
	                    if( j>0 && Math.Abs( matrix[i,j]-matrix[i,j-1] ) == 1 ) {
	                        result[i,j] = Math.Max(result[i,j],
	                                result[i,j-1]+1);
	                        if( maxLenth < result[i,j] ) {
	                            maxLenth = result[i,j];
	                            maxRow = i;
	                            maxCol = j;
	                        }
	                    }
	                }
	            }
	        }
            
            for ( int i=0; i<rows ; i++ ) {
                string row = "";
	            for ( int j=0; j<cols ; j++ ) {
                    row += result[i,j]+" ";
                }
                Console.WriteLine( row );
            }

	        //Now we will check the max entry in the result[][].
	        Console.WriteLine("Max Snake Sequence : " + maxLenth);
	        //printPath(matrix, result, maxLenth, maxRow, maxCol);
	        return 0;
	    }

	    public static int getMaxSnakeSequenceRec( int[,] matrix ) {
	    	
	    }
   }
}