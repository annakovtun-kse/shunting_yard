namespace Algorithms;

public class Tokenization
{

    public List<string> Tokenize(string input)
    {
        List<char> operators = ['-', '+', '*', '^', '/', '=', '^'];
        
        List<string> functions = ["sin", "cos", "max"];
        List<string> result = new List<string>();
        List<char> bufffer = new List<char>();
        List<char> bufferForFunc = new List<char>();
            
        foreach (var symbol in input)
        {

            if (Char.IsAsciiDigit(symbol) || symbol == '.' || symbol == ',')
            {
                if (bufferForFunc.Count > 0)
                {
                    bufferForFunc.Add(symbol);
                }
                else
                {
                    bufffer.Add(symbol);
                }
            }
            else if (Char.IsWhiteSpace(symbol))
            {
                continue;
            }
            else if (operators.Contains(symbol))
            {
                if (symbol == '-' && bufffer.Count == 0 && (result.Count == 0 || operators.Contains(result.Last()[0])))
                {
                    bufffer.Add(symbol);
                    continue;
                }

                if (bufffer.Count > 0)
                {
                    result.Add(string.Join("", bufffer));
                    bufffer.Clear();
                }

                result.Add(Convert.ToString(symbol));
            }
            else if (symbol == '(' || symbol == ')')
            {
                if (symbol == '(' && functions.Contains(string.Join("", bufferForFunc)))
                {
                    result.Add(string.Join("", bufferForFunc));
                    bufferForFunc.Clear();
                }
                else
                {
                    if (bufffer.Count > 0)
                    {
                        result.Add(string.Join("", bufffer));
                        bufffer.Clear();
                    }
                }
                result.Add(Convert.ToString(symbol));
            }
            else if(Char.IsAsciiLetter(symbol))
            {
                
                bufferForFunc.Add(symbol);
            }
            else
            {
                throw new ArgumentException("Incorrect input");
            }
        }
        if (bufffer.Count > 0)
        {
            result.Add(string.Join("", bufffer));
        }
        if (bufferForFunc.Count > 0)
        {
          result.Add(string.Join("", bufferForFunc));
        }
        return result;
    }
}
        


