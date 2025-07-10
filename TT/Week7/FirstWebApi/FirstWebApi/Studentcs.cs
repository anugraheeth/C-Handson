namespace FirstWebApi
{
    public class Studentcs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        public Studentcs(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;

        }
    }
}
