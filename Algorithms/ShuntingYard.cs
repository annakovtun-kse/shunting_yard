namespace Algorithms;
public enum Associations { Left, Right }
public class Operator
{
    public int Precedence { get; set; }
    public Associations Associations { get; set; }
    public Func<double, double, double> Calculate { get; set; }
}

public class WorkWithOperators
{
    public static Dictionary<string, Operator> Operators = new()
    {
        { "+", new Operator { Precedence = 2, Associations = Associations.Left, Calculate = ((a, b) => a + b) } },
        { "-", new Operator { Precedence = 2, Associations = Associations.Left, Calculate = ((a, b) => a - b) } },
        { "*", new Operator { Precedence = 3, Associations = Associations.Left, Calculate = ((a, b) => a * b) } },
        { "/", new Operator { Precedence = 3, Associations = Associations.Left, Calculate = ((a, b) => a / b) } },
        { "^", new Operator() { Precedence = 4, Associations = Associations.Right, Calculate = Math.Pow } }
    };
}

public class ShuntingYard
{
    private Dictionary<string, Operator> _operators = WorkWithOperators.Operators;
    public StackClass<string> StackClass { get; private set; } = new StackClass<string>();
    public QueueClass<string> QueueClass { get; private set; } = new QueueClass<string>();

    public StackClass<double> stackForCalcul { get; private set; } = new StackClass<double>();
    public void ToRPN(List<string> tokens)
    {
        foreach (var token in tokens)
        {
            if (token.All(char.IsAsciiDigit))
            {
                QueueClass.Enqueue(token);
                
            }
            else if (token == "(")
            {
                StackClass.Push(token);
                
            }
            else if (token == ")")
            {
                while (StackClass.Count() > 0 && StackClass.Peek() != "(")
                {
                    QueueClass.Enqueue(StackClass.Pop());
                }

                StackClass.Pop();
            }
            else if (_operators.ContainsKey(token))
            {
                while (StackClass.Count() > 0 && _operators.ContainsKey(StackClass.Peek()))
                {
                    var operator1 = _operators[token];
                    var operator2 = _operators[StackClass.Peek()];
                    if (operator1.Associations == Associations.Left && operator1.Precedence <= operator2.Precedence ||
                        operator1.Associations == Associations.Right && operator1.Precedence <= operator2.Precedence)
                    {
                        QueueClass.Enqueue(StackClass.Pop());
                    }
                    else
                    {
                        break;
                    }
                } 
                StackClass.Push(token);
            }
        }
        while (StackClass.Count() > 0)
        {
            QueueClass.Enqueue(StackClass.Pop());
        }
    }
    public double Calculation(QueueClass<string> rpn)
    {
        if (stackForCalcul.Count() <= 2)
        {
            Console.WriteLine("Incorrect expression");
            return 0.0;
        }
        while (rpn.Count() > 0)
        {
            string token = rpn.Dequeue();
            if (token.All(char.IsAsciiDigit))
            {
                bool canParse = double.TryParse(token, out var num);
                stackForCalcul.Push(num);
            }
            else if (_operators.ContainsKey(token))
            {
                double num1 = stackForCalcul.Pop();
                double num2 = stackForCalcul.Pop();
                double result = _operators[token].Calculate(num2, num1);
                stackForCalcul.Push(result);
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine(stackForCalcul.Pop());
        return stackForCalcul.Pop();
    }
    
}


