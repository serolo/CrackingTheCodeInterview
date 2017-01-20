/*
Given a list of numbers and a sum, return true or false if two numbers are 
add to the summ

Input:
3 4 7 8 1
14

Output:
Sol Quadratic: False
Sol Lineal: False

Example: 
	array -> 3 4 7 8 1
	
	Sum: 	12 -> true ( 8+4 )
			10 -> true ( 7+3 )
			14 -> false

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
			string[] numberStrings = Console.ReadLine().Split(' ');
            
			int[] numbers = new int[numberStrings.Length];
			for( int i=0; i<numberStrings.Length; i++ ) {
				numbers[i] = Convert.ToInt32( numberStrings[i] );
			}

			int sum = Convert.ToInt32( Console.ReadLine() );

			Console.WriteLine("Sol Quadratic: " + QuadraticSolution(numbers, sum ) );
			Console.WriteLine("Sol Lineal: " + LinealSolution(numbers, sum ) );
        }

        /*
            Time Complexity: O(n^2)
            Space Complexity: O(1)
        */
        public static bool QuadraticSolution( int[] numbers, int sum ) {
        	for( int i=0 ; i<numbers.Length; i++ ) {
        		for( int j=0 ; j<numbers.Length; j++ ) {
        			if( i != j) {
        				if( sum == numbers[i] + numbers[j] ) {
        					return true;
        				}
        			}
        		}
        	}
        	return false;
        }

        /*
            Time Complexity: O(n)
            Space Complexity: O(3)
        */
        public static bool LinealSolution( int[] numbers, int sum ) {
        	Sort sort = new Sort();
        	sort.MergeRecursive( numbers, 0, numbers.Length-1 );
        	if( numbers[0] > sum ) {
        		return false;
        	}

        	int infIndex = 0, supIndex = numbers.Length-1;
        	while( infIndex < supIndex ) {
        		if( numbers[supIndex] > sum ) {
        			supIndex--;
        		}
				else if( sum == numbers[infIndex] + numbers[supIndex] ) {
        			return true;
        		}
        		else if( sum < numbers[infIndex] + numbers[supIndex] ) {
        			supIndex--;
        		}
        		else {
        			infIndex++;
        		}
        	}
            
            return false;
        }
    }

    public class Sort 
    { 
        public void Merge ( int[] a, int lo, int middle, int hi )
        {
            //Create a copy array
            int[] copy = new int[a.Length];
            for( int i=0 ; i<a.Length ; i++ ) {
                copy[i] = a[i];
            }

            int left = lo, right=middle+1;
            for( int i=lo ; i<=hi ; i++ ) {
                if( left > middle ) {
                    a[i] = copy[right++];
                }
                else if( right > hi ) {
                    a[i] = copy[left++];
                }
                else if( copy[left] > copy[right] ) {
                    a[i] = copy[right++];
                }
                else {
                    a[i] = copy[left++];
                }
                
            }
                         
        }
        
        /*
            Time Complexity: O(n log n)
            Space Complexity: O(log n)
        */
        public void MergeRecursive( int[] a, int lo, int hi )
        {
            if( hi > lo ) {
                int middle = (lo+hi)/2;
                MergeRecursive( a, lo, middle );
                MergeRecursive( a, (middle+1) , hi );
                
                Merge( a, lo, middle, hi );
            }
        }
    }
}