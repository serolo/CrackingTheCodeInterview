
// ====================== LINKED LIST ======================

public class Node<Item>
{
    Node next = null;
    Item data;

    public Node( Item d ) {
        this.data = d;
    }

    public void AppendToTail ( int d ) {
        Node end = new Node( d );
        Node n = this;
        while( n.next != null ) {
            n = n.next;
        }
        n.next = end;
    }

    public void DeleteNode( int d ) {
        Node n = this;
        while (n.next != null) {
            if ( n.next.data == d ) {
                n.next = n.next.next;
            }
            n = n.next;
        }
    }
    
    public void PrintElements() {
        Node n = this;
        while (n.next != null) {
            Console.WriteLine(n.data);
            n = n.next;
        }
        Console.WriteLine(n.data);
    }
}

// ====================== STACK ======================

public class LinkedListStack<Item> 
{
	Node top;

	public LinkedListStack() {
		top = null;
	}

	Node pop() 
	{
		if (top != null) 
		{
			Item item = top.data;
			top = top.next;
			return item;
		}
		return null;
	}
	
	void push(Item item) 
	{
		Node<Item> t = new Node<Item>(item);
		t.next = top;
		top = t;
	}
}

public class ArrayStack 
{
	private int[] elements;
	private int index;

	public ArrayStack( int capacity ) 
	{
		elements = new int[capacity];
		index = 0;
	}

	int pop() 
	{
		int value = elements[index];
		elements[index] = null;
		index--;
		return value;
		
	}
	
	void push(int item) 
	{
		element[index++] = item;
	}
}

public clas ResizingArrayStack 
{
	private int[] elements;
	private int index;

	public StackArray( int capacity ) 
	{
		elements = new int[capacity];
		index = 0;
	}

	void Resize( int capacity ) 
	{
		int[] copy = new int[index*2];
		for( int i=0 ; i<index ; i++ )
		{
			copy[i] = elements[i];
		}
		elements = copy;
	}

	int pop() 
	{
		int value = elements[index];
		elements[index] = null;
		index--;
		return value;
		
	}
	
	void push(int item) 
	{
		if( index == elements.lenght ) 
		{
			Resize( index*2 )		
		}
		
		elements[index++] = item;
	}
}

// ====================== QUEUE ======================

public class LinkedListQueue 
{
	Node first, last;
	
	public LinkedListQueue() 
	{
		first = null;
		last = null;
	}

	public bool isEmpty() 
	{
		return first == null;
	}

	public void enqueue(Object item) 
	{
		Node oldLast = last;
		last = new Node( item );
		if( isEmpty() ) 
		{
			first = last;
		}
		else
		{
			oldLast.next = last;
		}
	}
	
	public int dequeue() 
	{
		int item = first.item;
		first = first.next;
		if( isEmpty() ) 
		{
			last = null;
		}
		return item;
	}
}

public class ResizingArrayQueue
{
	int firstIndex;
	int lastIndex;

	public ResizingArrayQueue( int capacity ) 
	{

	}
}