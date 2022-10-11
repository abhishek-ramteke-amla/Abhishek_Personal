using System;
using System.Collections.Generic;

namespace CustomerCRUD.Data
{
    public partial class CustomerTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
