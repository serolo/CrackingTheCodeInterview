//Created by Sebastian Romero
/*
Given an arithmetic expressions string exp such as
(5+6)*(7+8)/(4+3)
, write a program to examine whether the pairs and the orders of “{“,”}”,”(“,”)”,”[“,”]”,”<“,”>” are balanced ( each opening symbol has a corresponding closing symbol and the pairs of parentheses are properly nested). 
For example, the program should print 1 for exp = “[()]{}{[()()]()}” and 0 for exp = “[(])”

Input								Output
[{()}]								1
([)]								0
{()[}]								0
(a+{b+c}-[d-e])+[f]-[g]				1
(5+6)*(7+8)/(4+3)					1
*/



using System;

public class Program {
	
	public int CheckBalanced( string expression ) {
		if( expression == null ) {
			return 0;
		}

		if( expression == "" ) {
			return 1;
		}

		Stack parentheses = new Stack();

		foreach( char character in expression ) {
			if( character == '{' || character == '(' || character == '[' || character == '<' ) {
				parentheses.Push( character );
			}
			else if( character == '}' || character == ')' || character == ']' || character == '>' ) {
				char lastParenthese = parentheses.Pop();
				if( character == '}' && lastParenthese != '{' ) {
					return 0;
				}
				if( character == ')' && lastParenthese != '(' ) {
					return 0;
				}
				if( character == ']' && lastParenthese != '[' ) {
					return 0;
				}
				if( character == '>' && lastParenthese != '<' ) {
					return 0;
				}
			}
		}

		return parentheses.IsEmpty();
	}

}

//Char Node implementation
public class Node {
	
	public Node next = null;
	public char data;

	public Node( char item ) {
		data = item;
	}
}

//Stack Class Implementation
public class Stack {
	public Node top;

	public Stack() {
		this.top = null;
	}

	public bool IsEmpty() {
		return top == null;
	}

	public char Pop() {
		if( IsEmpty() ) {
			return '\0';
		}

		char result = top.data;
		top = top.next;
		return result;
	}

	public void Push( char item ) {
		Node t = new Node( item );
		t.next = top;
		top = t;
	}
}