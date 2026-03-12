using Algorithms;

var t = new Tokenization();
// foreach (var symb in t.Tokenize("7+  3 +  4*  5"))
// {
//     Console.Write($"{symb}.");
// }
//
ShuntingYard sh = new ShuntingYard();
List<string> tokenized = t.Tokenize("max(1, 4, 800.6)");
foreach (var tok in tokenized)
{
    Console.Write(tok);
}

sh.ToRPN(tokenized);
var res = sh.QueueClass;
res.ShowQueue();
// sh.Calculation(sh.QueueClass);
//
// // sh.ToRPN(tokenized);
// // sh.QueueClass.ShowQueue();
// // sh.Calculation(sh.QueueClass);
//
// bool canParse = double.TryParse("800.6", out var num);
// Console.WriteLine(canParse);