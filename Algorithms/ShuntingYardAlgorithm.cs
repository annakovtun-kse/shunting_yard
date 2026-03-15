namespace Algorithms;
using System;
using System.Globalization;
using System.Linq;

public enum Associations { Left, Right }

public class Operator
{
    public string Symbol { get; set; } 
    public int Precedence { get; set; }
    public Associations Associations { get; set; }
    public int Arity { get; set; }
    
    public Func<ArrayList<float>, float> Calculate { get; set; }
}

public class WorkWithOperators
{
    public static Operator[] Operators = new Operator[]
    {
        new Operator
        {
            Symbol = "+", Precedence = 2, Associations = Associations.Left,
            Arity = 2,
            Calculate = (args) => args.GetAt(0) + args.GetAt(1)
        },
        new Operator
        {
            Symbol = "-", Precedence = 2, Associations = Associations.Left,
            Arity = 2,
            Calculate = (args) => args.GetAt(1) - args.GetAt(0)
        },
        new Operator
        {
            Symbol = "*", Precedence = 3, Associations = Associations.Left,
            Arity = 2,
            Calculate = (args) => args.GetAt(0) * args.GetAt(1)
        },
        new Operator
        {
            Symbol = "/", Precedence = 3, Associations = Associations.Left,
            Arity = 2,
            Calculate = (args) => args.GetAt(0) / args.GetAt(1)
        },
        new Operator
        {
            Symbol = "^", Precedence = 4, Associations = Associations.Right,
            Arity = 2,
            Calculate = args => (float)Math.Pow(args.GetAt(0), args.GetAt(1))
        },
        new Operator
        {
            Symbol = "sin", Precedence = 5, Associations = Associations.Right,
            Arity = 1, // 1 аргумент
            Calculate = (args) => (float)Math.Sin(args.GetAt(0))
        },
        new Operator
        {
            Symbol = "cos", Precedence = 5, Associations = Associations.Right,
            Arity = 1, // 1 аргумент
            Calculate = (args) => (float)Math.Cos(args.GetAt(0))
        },
        new Operator
        {
            Symbol = "max", Precedence = 5, Associations = Associations.Right,
            Arity = 2, 
            Calculate = (args) =>
            {
                
                return args.Max();
            }
        },
        new Operator { 
            Symbol = "~", 
            Precedence = 6, 
            Associations = Associations.Right, 
            Arity = 1, 
            Calculate = (args) => -args.GetAt(0)
        }
        
    };


    public static bool ContainsOperator(string symbol)
    {
        for (int i = 0; i < Operators.Length; i++)
        {
            if (Operators[i].Symbol == symbol)
            {
                return true;
            }
        }
        return false;
    }

    public static Operator GetOperator(string symbol)
    {
        for (int i = 0; i < Operators.Length; i++)
        {
            if (Operators[i].Symbol == symbol)
            {
                return Operators[i];
            }
        }
        throw new ArgumentException($"Operator {symbol} not found");
    }
}

public class ShuntingYard
{
    public StackClass<string> StackClass { get; private set; } = new StackClass<string>();
    public QueueClass<string> QueueClass { get; private set; } = new QueueClass<string>();
    public StackClass<float> StackForCalcul { get; private set; } = new StackClass<float>();
    
    public void ToRPN(ArrayList<string> tokens)
    {
        for (int i = 0; i < tokens.Count(); i++)
        {
            string token = tokens.GetAt(i);

            if (float.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
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

            else if (WorkWithOperators.ContainsOperator(token))
            {
                while (StackClass.Count() > 0 && WorkWithOperators.ContainsOperator(StackClass.Peek()))
                {
                    var operator1 = WorkWithOperators.GetOperator(token);
                    var operator2 = WorkWithOperators.GetOperator(StackClass.Peek());
                    
                    if (operator1.Associations == Associations.Left &&
                        operator1.Precedence < operator2.Precedence ||
                        operator1.Associations == Associations.Right &&
                        operator1.Precedence < operator2.Precedence)
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
            else if (token == ",")
            {
                while (StackClass.Count() > 0 && StackClass.Peek() != "(")
                {
                    QueueClass.Enqueue(StackClass.Pop());
                }
            }
            else if (token.All(char.IsAsciiLetter))
            {
                QueueClass.Enqueue(token);
            }
        }

        while (StackClass.Count() > 0)
        {
            QueueClass.Enqueue(StackClass.Pop());
        }
    }

    public float Calculation(QueueClass<string> rpn)
    {
        while (rpn.Count() > 0)
        {
            string token = rpn.Dequeue();
            bool canParse = float.TryParse(token,NumberStyles.Any, CultureInfo.InvariantCulture, out var num);
            if (canParse)
            {
                StackForCalcul.Push(num);
            }
            else if (WorkWithOperators.ContainsOperator(token))
            {
                Operator currentOperator = WorkWithOperators.GetOperator(token);
                ArrayList<float> buffer = new ArrayList<float>();
                for (int i = 0; i < currentOperator.Arity; i++)
                {
                    if (StackForCalcul.Count() > 0)
                    {
                        buffer.Add(StackForCalcul.Pop());
                    }
                    else
                    {
                        throw new InvalidOperationException($"Incorrect input.");
                    }
                }
                
                float result = currentOperator.Calculate(buffer);
                StackForCalcul.Push(result);
            }
            else
            {
                continue;
            }
        }

        float finalResult = StackForCalcul.Pop();
        Console.WriteLine(finalResult);
        return finalResult;
    }
}