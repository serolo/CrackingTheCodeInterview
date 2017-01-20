//Trees

public class BinaryTree<T> {
	
	public class Node {
		public T data;
		public Node left;
		public Node right;

		public Node( T d ) {
			this.data = d;
			this.left = null;
			this.right = null;
		}
	}

	public Node root;

	public BinaryTree() {
		root = null;
	}

	public void VisitNode() {
		//Do whatever you want
		Console.Write( node.value );
	}

	#region INSERT METHODS

	public void Insert( T d ) {
		this.InsertRecursive( root, d );
	}

	private Node InsertRecursive( Node node, T d ) {
		if( root == null ) {
			Node node = new Node( d );
			root = node;
		}
		else if( node.data > d ) {
			node.left = Insert( node.left , d );
		}
		else {
			node.right = Insert( node.right, d );
		}
	}

	private Node InsertIterative( T d ) {
		//TODO: Implement
	}

	public bool ExistNode ( T d ) {
		return root.SearchRecursive( d ) != null;
	}

	#endregion

	#region SEARCH METHODS

	public Node SearchRecursive( Node node, T d) {
		if( node == null ) {
			return null;
		}

		if( node.data == d ) {
			return node;
		}

		if( node.data > d ) {
			return SearchRecursive( node.left, d );
		}
		else {
			return SearchRecursive( node.right, d );
		}
	}

	public Node SearchIterative( T d ) {
		Node node = root;
		while( node.data != d && node != null ) {
			if( node.data > d ) {
				node = node.left;
			}
			else {
				node = node.right;
			}
		}
		return node;
	}

	public Node SearchMin( Node node ) {
		if( node == null ) {
			return null;
		}
		if( node.left == null ) {
			return node;
		}
		else {
			return SearchMin( node.left );
		}
	}

	public Node SearchMax( Node node ) {
		if( node == null ) {
			return null;
		}
		if( node.right == null ) {
			return node;
		}
		else {
			return SearchMax( node.right );
		}
	}

	#endregion

	#region DELETE METHODS

	public bool DeleteNode( T d ) {

	}

	public void DeleteRecursive( Node node, T d) {
		if( node == null ) {
			return;
		}
		if( node.data > d ) {
			DeleteRecursive( node.left, d );
		}
		else if( node.data < d ) {
			DeleteRecursive( node.right, d );
		}
		else {
			//No child nodes
			if( node.right == null && node.left == null ) {
				node = null;
			}
			//No right child
			else if( node.right == null && node.left != null ) {
				node = node.left;
			}
			//No left child
			else if( node.right != null && node.left == null ) {
				node = node.right;
			}
			else {
				//Copy min in right
				//Copy that value to the current node
				//delete duplicate from right sub-tree
				//OR
				//Copy max in left
				//Copy that value to the current node
				//delete duplicate form left sub-tree
				Node min = this.SearchMin( node.right );
				node.data = min.data;
				DeleteRecursive( node.right, min.data );
			}
		}
	}

	#endregion

	#region TRANSVERSAL METHODS

	public void InOrderTraversal() {
		if( node != null ) {
			InOrderTraversal( root.left );
			VisitNode( root );
			InOrderTraversal( root.right );
		}
	}

	public void PreOrderTransversal() {
		if( node != null ) {
			VisitNode( root );
			PreOrderTransversal( root.left );
			PreOrderTransversal( root.right );
		}
	}

	public void PostOrderTransversal() {
		if( node != null ) {
			PostOrderTransversal( root.left );
			PostOrderTransversal( root.right );
			VisitNode( root );
		}
	}

	#endregion
}