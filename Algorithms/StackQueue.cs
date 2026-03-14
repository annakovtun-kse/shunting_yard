namespace Algorithms;
using System;

public class StackClass<T>
{
    public ArrayList<T> Stack { get; private set; } = new ArrayList<T>();
    
    public void Push(T thingToAdd) => Stack.Add(thingToAdd);

    public T Pop()
    {
        if (Stack.Count() == 0)
        {
            Console.WriteLine("Stack is empty");
            return default;
        }
        
        T lastItem = Stack.GetAt(Stack.Count() - 1);
        Stack.RemoveAt(Stack.Count() - 1); 
        return lastItem;
    }

    public int Count() => Stack.Count();

    public T Peek()
    {
        if (Stack.Count() == 0)
        {
            Console.WriteLine("Stack is empty");
            return default;
        }
        else
        {
            return Stack.GetAt(Stack.Count() - 1);
        }
    }

    public void ShowStack()
    {
        for (int i = 0; i < Stack.Count(); i++)
        {
            Console.WriteLine(Stack.GetAt(i));
        }
    }
}

public class QueueClass<T>
{
    public ArrayList<T> Queue { get; private set; } = new ArrayList<T>();

    public void Enqueue(T thingToAdd) => Queue.Add(thingToAdd);

    public T Dequeue()
    {
        if (Queue.Count() == 0)
        {
            Console.WriteLine("Queue is empty");
            return default;
        }
        T firstItem = Queue.GetAt(0);
        Queue.RemoveAt(0); 
        return firstItem;
    }

    public void ShowQueue()
    {
        for (int i = 0; i < Queue.Count(); i++)
        {
            Console.WriteLine(Queue.GetAt(i));
        }
    }

    public int Count() => Queue.Count();
}