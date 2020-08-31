using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApplication.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public int Roleid { get; set; }
        public Role Role { get; set; }

        public List<Patient> Patients { get; set; }
    }
}



