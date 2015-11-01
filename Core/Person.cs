using System;

namespace docker_people_service
{
     public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public string Middle { get; set; }

    }

    public class Address
    {
        public int Id { get; set; }
        public string  Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class PersonMajor
    {
        public int Id { get; set; }
        public Person ItemPersonData { get; set; }
        public Person ItemPersonEmergencyContactData { get; set; }
        public Address ItemPersonAddressData1 { get; set; }
        public Address ItemPersonAddressData2 { get; set; }

        public string ItemPhoneNumberData1 { get { return "111-222-3434"; } set { } }
        public string ItemPhoneNumberData2 { get { return "111-222-3434"; } set { } }
    }

    
}