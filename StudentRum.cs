using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    /*
    public class StudentRum
    {
        private int RumID;
        private string RumsTyp;
        private string Status;

        public Byggnad Byggnad;
    }
    */

    public class StudentRum
    {
        // === 1. Attribut (Data) ===

        // ÅTGÄRD 1: Ge standardvärden till alla non-nullable strings
        // Detta löser varningarna för RumID, Rumstyp och Status i standardkonstruktorn.

        // Unikt ID för rummet (t.ex. "305A").
        public string RumID { get; set; } = string.Empty;

        // Typ av rum, t.ex. "Enkelrum", "Delat rum".
        public string Rumstyp { get; set; } = string.Empty;

        // Rumstatus är kritiskt för ansökningslogiken.
        public string Status { get; set; } = "Ledig";


        // === 2. Relations-Property ===
        // Denna property är en omvänd koppling (back-reference) till kontraktet.

        // ÅTGÄRD 2: Gör egenskapen Nullable med '?'
        // Löser varningen för 'AktivtKontrakt' (eftersom rummet kan vara ledigt).
        public BoendeKontrakt? AktivtKontrakt { get; set; }


        // === 3. Konstruktorer ===

        // Primär konstruktor för att skapa ett nytt rum. (Denna är redan bra)
        public StudentRum(string rumID, string rumstyp, string status = "Ledig")
        {
            this.RumID = rumID;
            this.Rumstyp = rumstyp;
            this.Status = status;
            // AktivtKontrakt lämnas som null som standard, men är nu nullable.
        }

        // Standardkonstruktor. (Kan behållas)
        public StudentRum() { }


        // === 4. Metoder (Operationer) ===

        public void UppdateraStatus(string nyStatus)
        {
            this.Status = nyStatus;
        }

        public string VisaInfo()
        {
            return $"Rum ID: {RumID}, Typ: {Rumstyp}, Status: {Status}";
        }
    }
}
