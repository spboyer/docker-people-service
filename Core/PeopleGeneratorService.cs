using System;
using System.Collections.Generic;

namespace docker_people_service.Core
{
    public interface IPeopleGeneratorService
    {
        PersonMajor[] GenerateMajorPeople(int numberOfPeople);
    }
    
    public class PeopleGeneratorService : IPeopleGeneratorService
    {
        private static string[] LastNames = new string[] { "Lockrem", "Black", "Milfert", "Smith", "Jones", "Johnson", "Peterson", "Jameson", "Boyer", "Roy" };
        private static string[] FirstNames = new string[] { "William", "Matt", "Lisa", "Arianna", "Kristina", "Tyler", "Ryan", "Dylan", "Abby", "Kayla", "Kirsty", "Shayne" };
        private static string[] Middles = new string[] { "S", "E", "T", "H", "A", "C", "L", "D", "M", "O", "W" };
        private static int[] Ages = new int[] { 24, 16, 22, 34, 45, 43, 19, 21, 60, 42, 25, 36, 56, 87, 14, 25, 36, 47, 58, 69, 41, 52, 63, 45, 12, 78 };
        private static string[] Streets = new string[] { "1123 Main St", "3456 First Ave", "654 Second St", "232 Round Way", "124 Third Blvd", "444 Fourth Ave" };
        private static string[] Cities = new string[] { "Funny", "Purpose", "Brave", "Unknown", "Jedi", "Hero", "Smithe", "Anywhere" };
        private static string[] States = new string[] { "FL", "VA", "CA", "WA", "ME", "NY", "GA", "OR" };
        private static string[] ZipCodes = new string[] { "12345", "34568", "94759", "23444", "28474", "19373", "88774", "21344" };

        public PersonMajor[] GenerateMajorPeople(int numberOfPeople)
        {
            var people = new List<PersonMajor>(numberOfPeople);
            for (int i = 0; i < numberOfPeople; i++)
            {
                var personMajor =CreateMajorPerson(i);
                personMajor.Id = i +1;
                people.Add(personMajor);
            }
            return people.ToArray();
        }

        private Person CreatePerson(int i)
        {
            i = i + 1;
            Random rnd = RandomProvider.GetThreadRandom();
            var fn = rnd.Next(0, FirstNames.Length);
            var ln = rnd.Next(0, LastNames.Length);
            var a = rnd.Next(0, Ages.Length);
            var m = rnd.Next(0, Middles.Length);

            return new Person() { Id = i, First = FirstNames[fn], Last = LastNames[ln], Age = Ages[a], Middle = Middles[m] };
        }

        private PersonMajor CreateMajorPerson(int i)
        {
            var person = new PersonMajor();
            person.ItemPersonAddressData1 = CreateAddress(i);
            person.ItemPersonAddressData2 = CreateAddress(i);
            person.ItemPersonData = CreatePerson(i);
            person.ItemPersonEmergencyContactData = CreatePerson(i);

            return person;
        }

        private Address CreateAddress(int i)
        {
            i = i + 1;
            Random rnd = RandomProvider.GetThreadRandom();
            var str = rnd.Next(0, Streets.Length);
            var cty = rnd.Next(0, Cities.Length);
            var state = rnd.Next(0, States.Length);


            return new Address() { Id = i, City = Cities[cty], State = States[state], Street = Streets[str], ZipCode = ZipCodes[state] };
        }
    }
}
