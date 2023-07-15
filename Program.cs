// See https://aka.ms/new-console-template for more information

using System.Text;
Console.WriteLine();
Console.WriteLine("3..2..1..");
Console.WriteLine("Hallo, World!");

var funcs = new Dictionary<string, string>
{
    { "printChar(", "" },
    { "printLine(", "" },
    { "print(", "" }
};

var keyWords = new[] { "print(" };

using var sr = new StreamReader("../../../Code.txt");

while (sr.Peek() >= 0)
{
    var line = sr.ReadLine().Trim().ToLower();

    if (line.Contains('(') && !line.Contains(')'))
    {
        Console.WriteLine($"ERROR: line '{line}' had an opening paranth but not a closing one");
    }

    if (!string.IsNullOrWhiteSpace(line) && !line.EndsWith(';'))
    {
        Console.WriteLine($"ERROR: line '{line}' did not end with ;");
    }

    var pieces = line.Split(" ");
    var param = String.Empty;

    for (int i = 0; i < pieces.Length; i++)
    {
        if (i > 0 && i < pieces.Length - 2 && pieces[i + 1] == "=" && pieces[i - 1] != "var")
        {
            Console.WriteLine($"ERROR: variable '{pieces[i]}' was not declared as 'var myVar = '");
        }

        if (funcs.ContainsKey(pieces[i]))
        {
            Console.Write($"func initiated with {pieces[i]}");
            var thingToDo = funcs[pieces[i]];
        }

        if (pieces[i].EndsWith('(') && keyWords.Contains(pieces[i]))
        {
            var sb = new StringBuilder(" and printed message is: ");
            for (int j = i + 1; j < pieces.Length; j++)
            {
                if (!pieces[j].StartsWith(')'))
                {
                    // sb.Append(j);
                    sb.Append($"{pieces[j]} ");
                }
            }

            param = sb.ToString();
            Console.WriteLine(param);
        }
    }
    // Console.Write((char)sr.Read());
}