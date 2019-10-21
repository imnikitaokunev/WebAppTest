namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person FindPerson(string name);
        void AddPerson(Person newPerson);
    }
}