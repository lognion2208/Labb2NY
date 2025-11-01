using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Användare
    {
        public string Namn { get; set; }
        public string Epost { get; set; }
        public string Lösenord { get; set; }
        public string Status { get; set; }


            //konstruktor här ?
        public Användare()
        {
            //denna är tom... lägger till en full under så kan vi ta bort ena eller ksk så kan man ha kvar båda. tror tom funkar den med, men inte lika flexibel när det kommer till epost, lösen mm (kan ha fel)
        }

        public Användare(string namn, string epost, string lösenord, string status)
        {
            Namn = namn;
            Epost = epost;
            Lösenord = lösenord;
            Status = status;
        }

    }  
}
