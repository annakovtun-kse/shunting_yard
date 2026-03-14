namespace Algorithms;
using System;

public class Tokenizer
{
    private string BufferToString(ArrayList<char> buffer)
    {
        char[] chars = new char[buffer.Count()];
        for (int i = 0; i < buffer.Count(); i++)
        {
            chars[i] = buffer.GetAt(i);
        }
        return new string(chars);
    }
    
    private bool IsOperator(char symbol)
    {
        char[] operators = new char[] { '-', '+', '*', '^', '/', '=' };
        for (int i = 0; i < operators.Length; i++)
        {
            if (operators[i] == symbol)
            {
                return true;
            }
        }
        return false;
    }

    
    public ArrayList<string> Tokenize(string input)
    {
        ArrayList<string> result = new ArrayList<string>();
        ArrayList<char> bufffer = new ArrayList<char>();
        ArrayList<char> bufferLetter = new ArrayList<char>();
        
        for (int i = 0; i < input.Length; i++)
        {
            char symbol = input[i];

            if (Char.IsAsciiDigit(symbol) || symbol == '.')
            {
                bufffer.Add(symbol);
            }
            else if (Char.IsWhiteSpace(symbol))
            {
                continue;
            }
            else if (IsOperator(symbol))
            {
                bool hadOperandBefore = bufffer.Count() > 0 || bufferLetter.Count() > 0;

                if (bufffer.Count() > 0)
                {
                    result.Add(BufferToString(bufffer));
                    bufffer = new ArrayList<char>();
                }
                if (bufferLetter.Count() > 0)
                {
                    result.Add(BufferToString(bufferLetter)); 
                    bufferLetter = new ArrayList<char>();
                }
                
                if (symbol == '-' && !hadOperandBefore)
                {
                    bool isUnary = false;
                    
                    if (result.Count() == 0)
                    {
                        isUnary = true;
                    }
                    else
                    {
                        string lastToken = result.GetAt(result.Count() - 1);
                        if (lastToken == "(" || lastToken == "," || (lastToken.Length == 1 && IsOperator(lastToken[0])))
                        {
                            isUnary = true;
                        }
                    }

                    if (isUnary)
                    {
                        result.Add("~");
                        continue;
                    }
                }
                result.Add(Convert.ToString(symbol));
            }
            else if (symbol == '(' || symbol == ')')
            {
                if (bufffer.Count() > 0)
                {
                    result.Add(BufferToString(bufffer));
                    bufffer = new ArrayList<char>(); 
                }
                if (bufferLetter.Count() > 0)
                {
                    result.Add(BufferToString(bufferLetter));
                    bufferLetter = new ArrayList<char>(); 
                }
                result.Add(Convert.ToString(symbol));
            }
            else if (Char.IsAsciiLetter(symbol))
            {
                if (bufffer.Count() > 0) 
                {
                    result.Add(BufferToString(bufffer));
                    bufffer = new ArrayList<char>(); 
                }
                bufferLetter.Add(symbol);
            }
            else if (Convert.ToString(symbol) == ",")
            {
                result.Add(BufferToString(bufffer));
                bufffer = new ArrayList<char>();
                result.Add(Convert.ToString(symbol));
            }
            else
            {
                throw new ArgumentException("Incorrect input");
            }
        }
        
        if (bufffer.Count() > 0)
        {
            result.Add(BufferToString(bufffer));
        }
        
        return result;
    }
}