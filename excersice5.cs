/*
Given a binary tree and a number, search inside the tree if the sum of one of the paths is iqual to the number
and return true if you can find the numbers or false if not

Example:
	 3
   /   \
  5	    6
 / \   / \
4   2 1   4

Sum: 	12 -> true
		10 -> true
		15 -> false
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
            TreeNode root = new TreeNode(3);
			root.left = new TreeNode(5);
			root.right = new TreeNode(6);
			root.left.left = new TreeNode(4);
			root.left.right = new TreeNode(2);
			root.right.left = new TreeNode(1);
			root.right.right = new TreeNode(4);

			int sum = Convert.ToInt32( Console.ReadLine() );

			Console.WriteLine("Sol : " + HasPath(root, sum ) );
        }

        public static bool HasPath( TreeNode node, int sum ) {
        	if( node == null ) {
        		return false;
        	}

        	if( node.data > sum ) {
        		return false;
        	}

        	sum -= node.data;

        	if( sum == 0 ) {
        		return true;
        	}

        	return HasPath( node.left, sum) || HasPath( node.right, sum );
        }
    }
    
     public class TreeNode {
		public int data;
		public TreeNode left;
		public TreeNode right;

		public TreeNode( int d ) {
			this.data = d;
			this.left = null;
			this.right = null;
		}
	}
}