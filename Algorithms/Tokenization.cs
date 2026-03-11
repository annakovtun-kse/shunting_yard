namespace Algorithms;

public class Tokenization
{

    public List<string> Tokenize(string input)
    {
        List<char> operators = ['-', '+', '*', '^', '/', '=', '^'];
        List<string> result = new List<string>();
        List<char> bufffer = new List<char>();
        List<char> bufferLetter = new List<char>();
        foreach (var symbol in input)
        {
            if (Char.IsAsciiDigit(symbol) || symbol == '.' || symbol == ',')
            {
                bufffer.Add(symbol);
            }
            else if (Char.IsWhiteSpace(symbol))
            {
                continue;
            }
            else if (operators.Contains(symbol))
            {
                // if (symbol == '-' && bufffer.Count == 0 && (result.Count == 0 || operators.Contains(result.Last()[0])))
                // {
                //     bufffer.Add(symbol);
                //     continue;
                // }
                // if (bufffer.Count > 0)
                // {
                //     result.Add(string.Join("", bufffer));
                //     bufffer.Clear();
                // }
                
                if (bufffer.Count > 0)
                {
                    result.Add(string.Join("", bufffer));
                    bufffer.Clear();
                }
                if (bufferLetter.Count > 0)
                {
                    result.Add(string.Join("", bufferLetter)); 
                    bufferLetter.Clear();
                }
                result.Add(Convert.ToString(symbol));

            }
            else if (symbol == '(' || symbol == ')')
            {
                // if (bufffer.Count > 0)
                // {
                //     result.Add(string.Join("", bufffer));
                //     bufffer.Clear();
                // 
                if (bufffer.Count > 0)
                {
                    result.Add(string.Join("", bufffer));
                    bufffer.Clear();
                }
                if (bufferLetter.Count > 0)
                {
                    result.Add(string.Join("", bufferLetter)); // Додаємо будь-яке слово (sin, cos чи просто x)
                    bufferLetter.Clear();
                }
                result.Add(Convert.ToString(symbol));
            }
            else if (Char.IsAsciiLetter(symbol))
            {
                if (bufffer.Count > 0) 
                {
                    result.Add(string.Join("", bufffer));
                    bufffer.Clear();
                }
                bufferLetter.Add(symbol);
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
        return result;
    }
}