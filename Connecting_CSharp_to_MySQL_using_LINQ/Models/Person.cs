using System;
using System.Collections.Generic;

namespace Connecting_CSharp_to_MySQL_using_LINQ.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
