using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        List<Person> GetAll();
        Person FindPerson(string name);
        void AddPerson(Person newPerson);
    }
}