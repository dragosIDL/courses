
using System.Linq;

namespace GoingDeclarative.StatementsAndExpressions;

public class Statements
{
    public static int If(int x, int y, bool flag)
    {
        int result;
        if (flag)
        {
            result = x;
        }
        else
        {
            result = y;
        }
        return result;
    }

    public static int Switch(int x, int y, string str)
    {
        int result;
        switch (str)
        {
            case "x": result = x; break;
            case "y": result = y; break;
            default: result = x; break;
        }
        return result;
    }

    public static int Foreach()
    {
        var numbers = Enumerable.Range(0, 10);

        int sum = 0;
        foreach (var nr in numbers)
        {
            sum += nr;
        }
        return sum;
    }
}
