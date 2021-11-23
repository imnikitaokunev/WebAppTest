namespace PhoneBookTestApp
{
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Person()
        {
        }

        public Person(string name, string phoneNumber, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string GetInfo => $"{Name}, {PhoneNumber}, {Address}";
    }
}