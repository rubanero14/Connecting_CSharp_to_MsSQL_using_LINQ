using System;
using System.Collections.Generic;

namespace Connecting_CSharp_to_MsSQL_using_LINQ.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    } 
}
