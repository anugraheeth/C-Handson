using TempLibrary;

namespace Temperature_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Temperature tempConverter = new Temperature();

            double celsius = 25;
            double fahrenheit = tempConverter.CTF(celsius);
            Console.WriteLine($"{celsius} °C = {fahrenheit} °F");

            double f = 77;
            double c = tempConverter.FTC(f);
            Console.WriteLine($"{f} °F = {c} °C");
        }
    }
}
