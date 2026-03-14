// namespace Algorithms;
// using System.Globalization;
// public enum Associations { Left, Right }
// public class Operator
// {
//     public int Precedence { get; set; }
//     public Associations Associations { get; set; }
//     public Func<List<float>, float> Calculate { get; set; }
// }
//
// public class WorkWithOperators
// {
//     public static Dictionary<string, Operator> Operators = new()
//     {
//         {
//             "+",
//             new Operator { Precedence = 2, Associations = Associations.Left, Calculate = (args) => args[0] + args[1] }
//         },
//         {
//             "-",
//             new Operator { Precedence = 2, Associations = Associations.Left, Calculate = (args) => args[1] - args[0] }
//         },
//         {
//             "*",
//             new Operator { Precedence = 3, Associations = Associations.Left, Calculate = (args) => args[0] * args[1] }
//         },
//         {
//             "/",
//             new Operator { Precedence = 3, Associations = Associations.Left, Calculate = (args) => args[0] / args[1] }
//         },
//         {
//             "^",
//             new Operator
//                 { Precedence = 4, Associations = Associations.Right, Calculate = args => (float)Math.Pow(args[0], args[1]) }
//         },
//         {
//             "sin",
//             new Operator()
//                 { Precedence = 5, Associations = Associations.Right, Calculate = (args) => (float)Math.Sin(args[0]) }
//         },
//         {
//             "cos",
//             new Operator()
//                 { Precedence = 5, Associations = Associations.Right, Calculate = (args) => (float)Math.Cos(args[0]) }
//         },
//         {
//             "max",
//             new Operator() { Precedence = 5, Associations = Associations.Right, Calculate = (args) => args.Max() }
//         }
//     };
//
// }
//
// public class ShuntingYard
// {
//     private Dictionary<string, Operator> _operators = WorkWithOperators.Operators;
//     public StackClass<string> StackClass { get; private set; } = new StackClass<string>();
//     public QueueClass<string> QueueClass { get; private set; } = new QueueClass<string>();
//
//     public StackClass<float> StackForCalcul { get; private set; } = new StackClass<float>();
//
//     public void ToRPN(List<string> tokens)
//     {
//         foreach (var token in tokens)
//         {
//             if (float.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
//             {
//                 QueueClass.Enqueue(token);
//             }
//             else if (token == "(")
//             {
//                 StackClass.Push(token);
//
//             }
//             else if (token == ")")
//             {
//                 while (StackClass.Count() > 0 && StackClass.Peek() != "(")
//                 {
//                     QueueClass.Enqueue(StackClass.Pop());
//                 }
//
//                 StackClass.Pop();
//             }
//             else if (_operators.ContainsKey(token))
//             {
//                 while (StackClass.Count() > 0 && _operators.ContainsKey(StackClass.Peek()))
//                 {
//                     var operator1 = _operators[token];
//                     var operator2 = _operators[StackClass.Peek()];
//                     if (operator1.Associations == Associations.Left &&
//                         operator1.Precedence < operator2.Precedence ||
//                         operator1.Associations == Associations.Right &&
//                         operator1.Precedence < operator2.Precedence)
//                     {
//                         QueueClass.Enqueue(StackClass.Pop());
//                     }
//                     else
//                     {
//                         break;
//                     }
//                 }
//
//                 StackClass.Push(token);
//             }
//             else if (token == ",")
//             {
//                 while (StackClass.Count() > 0 && StackClass.Peek() != "(")
//                 {
//                     QueueClass.Enqueue(StackClass.Pop());
//                 }
//             }
//             else if (token.All(char.IsAsciiLetter))
//             {
//                 QueueClass.Enqueue(token);
//             }
//             
//         }
//
//         while (StackClass.Count() > 0)
//         {
//             QueueClass.Enqueue(StackClass.Pop());
//         }
//     }
//
//
//
//     public float Calculation(QueueClass<string> rpn)
//         {
//     
//             while (rpn.Count() > 1)
//             {
//                 string token = rpn.Dequeue();
//                 if (token.All(char.IsAsciiDigit))
//                 {
//                     bool canParse = float.TryParse(token, out var num);
//                     StackForCalcul.Push(num);
//                 }
//                 else if (_operators.ContainsKey(token))
//                 {
//                     List<float> buffer = new List<float>();
//                     while (StackForCalcul.Count() > 0)
//                     {
//                         buffer.Add(StackForCalcul.Pop());
//                     }
//                     float result = _operators[token].Calculate(buffer);
//                     StackForCalcul.Push(result);
//                 }
//                 else
//                 {
//                     continue;
//                 }
//             }
//     
//             Console.WriteLine(StackForCalcul.Pop());
//             return StackForCalcul.Pop();
//         }
//     
//     }
//
//
