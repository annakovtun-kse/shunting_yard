using Algorithms;

var t = new Tokenization();
ShuntingYard sh = new ShuntingYard();
List<string> tokenized = t.Tokenize("max(1, 4, 800.6)");
foreach (var tok in tokenized)
{
    Console.Write(tok);
}

sh.ToRPN(tokenized);
var res = sh.QueueClass;
res.ShowQueue();
