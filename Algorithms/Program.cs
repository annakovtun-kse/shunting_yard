using Algorithms;

var t = new Tokenization();
// foreach (var symb in t.Tokenize("7+  3 +  4*  5"))
// {
//     Console.Write($"{symb}.");
// }

ShuntingYard sh = new ShuntingYard();
List<string> tokenized = t.Tokenize("(7+8) * 5");
foreach (var tok in tokenized)
{
    Console.Write(tok);
}
sh.ToRPN(tokenized);
sh.QueueClass.ShowQueue();
sh.Calculation(sh.QueueClass);
