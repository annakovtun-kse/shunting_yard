using System.Collections;
using Algorithms;

Tokenizer tokenizer = new Tokenizer();
ShuntingYard sh = new ShuntingYard();
string expression = Console.ReadLine();
var tokenizedExpression = new ArrayList<string>();
if (expression != null)
{
    tokenizedExpression = tokenizer.Tokenize(expression);
}

tokenizedExpression.Show();
sh.ToRPN(tokenizedExpression);
sh.QueueClass.ShowQueue();
sh.Calculation(sh.QueueClass);