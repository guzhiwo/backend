float first;
float second;
float result;

Console.Write("Input first number: ");

if (!float.TryParse(Console.ReadLine(), out first)) //out значит что аргумент передается по ссылке и будет изменен этой функцией
{
    Console.WriteLine("Whoops, incorrect input");
    return 1;
}

Console.Write("Input second number: ");

if (!float.TryParse(Console.ReadLine(), out second))
{
    Console.WriteLine("Whoops, incorrect input");
    return 1;
}

Console.Write("Input operation (+, -, *, /, ^): ");

switch(Console.ReadLine())
{
    case "+":
        result = first + second; 
        break;
    case "-":
        result = first - second; 
        break;
    case "*":
        result = first * second; 
        break;
    case "/":
        result = first / second; 
        break;
    case "^":
        result = (float)Math.Pow(first, second);
        break;
    default:
        Console.WriteLine("Whoops, incorrect input"); 
        return 1;
}

Console.WriteLine("Result: " + result);

return 0;