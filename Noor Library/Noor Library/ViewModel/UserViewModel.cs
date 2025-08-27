using Noor_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noor_Library.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string UserName{ get; set; }
        public string Email { get; set; }
       
        //public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        
      
        public IEnumerable<string> Roles { get; set; }

    }
}
