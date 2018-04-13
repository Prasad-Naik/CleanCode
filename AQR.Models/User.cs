using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQR.DomainModels
{
   public class User
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }

        public bool IsDeleted { get; set; }

        public Department Department { get; set; }
    }
}
