using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStoreApp.Model
{
    class Employee
    {
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Postion { get; set; }
        public int ReportsTo { get; set; }
        public string HireDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"{FirstName}, {LastName}";
        }
    }
}
