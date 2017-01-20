//Created by Sebastian Romero
/*

Given two dimen­sional matrix, write an algo­rithm to get the shortest paths to a specific point. 
You are allowed to move up, down, right and left.  
The matrix contains 0 or 1, where a 1 is a close route and a 0 is an open route.
Return the amount of the shortest route or -1 in case that the route doesn't exist.

input: 

matrix = [0,0,0,0,0], [0,0,0,0], [0,1,0,0], [0,0,0,0]
cols = 4
rows = 4
finalCol = 2
finalRow = 2

Result = 4

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
            int[,] arrA  = new int[,] { {0,1,0,0,0}, {0,0,0,1,0}, {1,1,1,1,0}, {0,0,0,0,0} };
            int finalRow = 2;
            int finalCol = 3;
            Console.WriteLine( count(arrA, 5, 4, 0, 0, finalRow, finalCol ) );
        }

        public static int count(int [,] arrA, int maxRow, int maxCol , int row, int col, int finalRow, int finalCol )
        {
            
            Console.WriteLine( "row: "+row );                        
            Console.WriteLine( "col: "+col );
            Console.WriteLine( "finalRow: "+finalRow );
            Console.WriteLine( "finalCol: "+finalCol );
           
            if( row == finalRow && col == finalCol ) {
                Console.WriteLine( "\\\\\\\\ end the recursive \\\\\\\\" );
                return 0;
            }

            int route = 0;

            //Move to the left untill we reach the final row or untill we find a block route
            if( col != finalCol && col != maxCol-1 && arrA[row, col+1] != 1 ) {
                Console.WriteLine( "Move to the left" );
                Console.WriteLine( "----------------" );
                route = 1+count(arrA, maxRow, maxCol, row, col+1, finalRow, finalCol );
            }

            //Move down untill we reach the final col or untill we find a block route
            else if( row != finalRow && row != maxRow-1 && arrA[row+1, col] != 1 ) {
                Console.WriteLine( "Move down" );
                Console.WriteLine( "----------------" );
                route = 1+count(arrA, maxRow, maxCol, row+1, col, finalRow, finalCol );
            }
            
            //Move up
            else if( row != finalRow && row != 0 && arrA[row-1, col] != 1 ) {
                Console.WriteLine( "Move up" );
                /*
                Console.WriteLine( "row: "+row );                        
                Console.WriteLine( "col: "+col );
                Console.WriteLine( "finalRow: "+finalRow );
                Console.WriteLine( "finalCol: "+finalCol );
                */
                Console.WriteLine( "----------------" );
                route = 1+count( arrA, maxRow, maxCol, row-1, col, finalRow, finalCol );
            }

            //Move to the right
            else if( col !=finalCol && col != 0 && arrA[row, col-1] != 1 ) {
                Console.WriteLine( "Move to the right" );
                Console.WriteLine( "----------------" );
                route = 1+count( arrA, maxRow, maxCol, row, col-1, finalRow, finalCol );
            }
            
            return route;
        }

        public int numberOfPathsRec( int [,] arrA, int maxRow, int maxCol , int row, int col, int finalRow, int finalCol ) {
            //base case
            //check if last row OR column is reached since after that only one path
            if( row ==finalRow && col==finalCol ){
                return 1;
            }

            int left =0;
            int down = 0;

            //move lo the left
            if( col != finalCol && col != maxCol-1 && arrA[row, col+1] != 1 ) {
                left = count(arrA, row+1, col);
            }

            //move down
            else if( row != finalRow && row != maxRow-1 && arrA[row+1, col] != 1 ) {
                down = count(arrA, row, col+1);
            }

            return left + down;
        }

        public int numberOfPathsDP( int [,] arrA, int maxRow, int maxCol , int row, int col, int finalRow, int finalCol ) {
            int result [][] = arrA;

            for (int i = 1; i <result.length ; i++) {
                for (int j = 1; j <result.length ; j++) {
                    if(result[i][j]!=-1){
                        result[i][j]=0;
                        if(result[i-1][j]>0)
                            result[i][j]+=result[i-1][j];
                        if(result[i][j-1]>0)
                            result[i][j]+=result[i][j-1];
                    }
                }
            }

            return result[arrA.length-1][arrA.length-1];
        }
    }
}