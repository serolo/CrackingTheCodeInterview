//Creatin by Sebastian Romero

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
            Sort sort = new Sort();
            //Your code goes here
            //Console.WriteLine("Hello, world!");
            Int32[] a = new Int32[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
            for( int i=0 ; i<a.Length ; i++ ) {
                Console.WriteLine( a[i] );
            }
            Console.WriteLine( "--------- Shuffle ---------" );
            sort.Shuffle(a);
            for( int i=0 ; i<a.Length ; i++ ) {
                Console.WriteLine( a[i] );
            }
            Console.WriteLine( "--------- Sort ---------" );
            sort.MergeRecursive( a, 0, a.Length-1 );
            for( int i=0 ; i<a.Length ; i++ ) {
                Console.WriteLine( a[i] );
            }
        }
    }
    
    
    public class Sort 
    {
        public void Shuffle( int[] a ) 
        {
            Random rnd = new Random();
            for( int i=0 ; i<a.Length; i++ ) {
                int random = rnd.Next( i+1 );
                this.Exchange(a,i, random);
            }
        }
        
        public void Selection( int[] a ) 
        {
            for( int i=0 ; i<a.Length ; i++ )
            {
                int min = i;
                for( int j=i+1 ; j<a.Length; j++ ) 
                {
                    if( a[min] > a[j] ) 
                    {
                        min = j;
                    }
                }
                this.Exchange(a,i,min);
            }
        }
        
        public void Insertion( int[] a )
        {
            for( int i=0; i<a.Length; i++ )
            {
                for( int j=i ; j>0 ; j-- ) 
                {
                    if( a[j] < a[j-1] ) 
                    {
                        this.Exchange(a,j,j-1);
                    }

                    else {
                        break;
                    }

                }
            }
        }
        
        public void Merge ( int[] a, int lo, int middle, int hi )
        {
            Trace.Assert( lo < hi || hi < middle || middle > hi , "Error in Merge method. the index are not in a correct order" );
            
            Trace.Assert( IsSorted( a, lo, middle ) );
            Trace.Assert( IsSorted( a, middle+1, hi ) );
            
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
        
        public void MergeRecursive( int[] a, int lo, int hi )
        {
            if( hi > lo ) {
                int middle = (lo+hi)/2;
                MergeRecursive( a, lo, middle );
                MergeRecursive( a, (middle+1) , hi );
                
                Merge( a, lo, middle, hi );
            }
        }
        
        public void MergeBottomUp( int[] a ) 
        {
            int lenght = a.Length;
            int[] comparable = new int[lenght];
            for( int sz=1 ; sz<lenght ; sz = 2*sz ) {
            	for( int lo=0 ; lo<lenght-sz; lo += sz+sz ) {
            		Merge( a, lo, lo+sz-1, Math.Min(lo+sz+sz-1, lenght-1) );
            	}
            }
        }
        
        private void Exchange( int[] a, int i, int j)
        {
            int change = a[i];
            a[i] = a[j];
            a[j] = change;
        }
        
        private bool IsSorted( int[] a, int lo, int hi ) 
        {
            Trace.Assert( hi < lo, "Error in IsSorted method. index lo is bigger than hi" );
            
            if(  hi == lo ) {
                return true;
            }
            
            for( int i=lo; i<hi-1 ; i++ ) {
                if( a[i] > a[i+1] ) {
                    return false;
                }
            }
            return true;
        }
    }
}