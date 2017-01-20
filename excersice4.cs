/*
Objec­tive: Given two strings, s1 and s2 and edit oper­a­tions (given below). Write an algo­rithm to find min­i­mum num­ber oper­a­tions required to con­vert string s1 into s2.

Allowed Oper­a­tions:

Inser­tion — Insert a new character.
Dele­tion — Delete a character.
Replace — Replace one char­ac­ter by another.

Example:

String s1 = "horizon"
String  s2 = "horzon"
Output: 1  {remove 'i' from string s1}

String s1 = "horizon"
String  s2 = "horizontal"
Output: 3  {insert 't', 'a', 'l' characters in string s1}
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

        public static int[] CalculateInserts( int[] matrix ) {

	    }

	    public static int getMaxSnakeSequenceRec( int[,] matrix ) {
	    	
	    }
   }
}