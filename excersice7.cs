/*
Given a binary tree check, create a function that return true if is a binary search tree 
or false in the case that is not.

Example:
1) Not a BST
     3
   /   \
  5     6
 / \   / \
4   2 1   4

2) BST
     5
   /   \
  4     8
 / \   / \
2   3 6   9

3) Not a BST
     5
   /   \
  2     8
 / \   
1   6 

http://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/



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
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(2);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(6);

            Console.WriteLine("Sol 1: " + IsABinarySearchTree1(root) );
            Console.WriteLine("Sol 2: " + IsABinarySearchTree2(root) );
        }
        
        /*
            Time Complexity: O(2^n)
            Space Complexity: O(n)
        */
        public static bool IsABinarySearchTree1( TreeNode root ) {
            if( root == null ) {
                return true;
            }

            if( root.left != null && root.left.data > root.data  ) {
                return false;
            }
            else if( root.right != null && root.right.data < root.data) {
                return false;
            }
            else {
                return IsABinarySearchTree1( root.left ) && IsABinarySearchTree1( root.right );
            }
        }
        
        /*
            Time Complexity: O(2^n)
            Space Complexity: O(n)
        */
        public static bool IsABinarySearchTree2( TreeNode root, int max = int.MaxValue, int min = int.MinValue ) {
            if( root == null ) {
                return true;
            }

            if (root.data < min || root.data > max) {
                return false;
            }

            return IsABinarySearchTree2(root.left, min, root.data-1) &&
                IsABinarySearchTree2(root.right, root.data+1, max);
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