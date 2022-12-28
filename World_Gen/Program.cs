double backNumber = 0;
double currentNumber = 1;

for (int i = 1; i < 100; i++)
{
    backNumber = i - 1;
    currentNumber = i;

    Console.WriteLine(Math.Pow(currentNumber, 2) - Math.Pow(backNumber, 2));
}