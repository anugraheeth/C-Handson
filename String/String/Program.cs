namespace String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first name:");
            string firstname = Console.ReadLine();
            Console.WriteLine($"First occurence of h : {firstname.IndexOf('h')}");
        }
    }
}
