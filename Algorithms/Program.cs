using System.Collections;
using Algorithms;

Tokenizer tokenizer = new Tokenizer();
ShuntingYard sh = new ShuntingYard();
var input = tokenizer.Tokenize("sin(1/6)");
sh.ToRPN(input);
sh.QueueClass.ShowQueue();
sh.Calculation(sh.QueueClass);