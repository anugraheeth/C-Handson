namespace TempLibrary
{
    public class Temperature
    {
        public double CTF(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
        
        public double FTC(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
