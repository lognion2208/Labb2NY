using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    /*
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
    */

    public class Användare
    {
        // === 1. Attribut (Data) med standardvärden ===

        // Genom att sätta = string.Empty; garanterar vi att dessa properties aldrig är null
        // vilket eliminerar Non-nullable property-varningarna.
        public string Namn { get; set; } = string.Empty;
        public string Epost { get; set; } = string.Empty;
        public string Lösenord { get; set; } = string.Empty;
        public string Status { get; set; } = "Aktiv"; // Default-status
        public string Personnummer { get; set; } = string.Empty;


        // === 2. Konstruktorer ===

        // Konstruktor som tar alla värden
        public Användare(string namn, string epost, string lösenord, string personnummer)
        {
            // Vi använder en default status på "Aktiv" här
            this.Namn = namn;
            this.Epost = epost;
            this.Lösenord = lösenord;
            this.Personnummer = personnummer;
            this.Status = "Aktiv";
        }

        // Standardkonstruktor (används t.ex. för deserialisering eller i vissa ärvda klasser)
        public Användare() { }


        // === 3. Gemensamma Metoder ===

        // Alla användare har en LoggaIn-funktion (även om logiken ligger i BoBoKontroll)
        public virtual void LoggaIn()
        {
            // Denna metod kan vara tom eller användas för loggning/events i en större applikation
        }
    }


}
