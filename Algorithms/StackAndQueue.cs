namespace Algorithms;

public class StackClass<T>
{
    public List<T> Stack { get; private set; } = new List<T>();
    public void Push(T thingToAdd) => Stack.Add(thingToAdd);

    public T Pop()
    {
        if (Stack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
            return default;
        }

        T lastItem = Stack[^1];
        Stack.RemoveAt(Stack.Count - 1);
        return lastItem;
    }

    public int Count() => Stack.Count;

    public T Peek()
    {
        if (Stack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
            return default;
        }
        else
        {
            return Stack[^1];
        }
    }

    public void ShowStack()
    {
        foreach (var el in Stack)
        {
            Console.WriteLine(el);
        }
        
    }


}

public class QueueClass<T>
{
    public List<T> Queue { get; private set; } = new List<T>();
    

    public void Enqueue(T thingToAdd) => Queue.Add(thingToAdd);

    public T Dequeue()
    {
        if (Queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default;
        }

        T lastItem = Queue[0];
        Queue.Remove(Queue[0]);
        return lastItem;
    }

    public void ShowQueue()
    {
        foreach (var el in Queue)
        {
            Console.WriteLine(el);
        }
    }

    public int Count() => Queue.Count;



}