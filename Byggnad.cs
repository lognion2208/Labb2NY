using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    /*
    public class Byggnad
    {

        private string Namn;
        private string Gata;
        private int Gatunummer;
        private int AntalRum;
        private string Status;

            public void HämtaRumInfo()
            {

            }

            public void LäggaTillStudent()
            {

            }

            public void UppdateraStudentRum()
            {

            }

            public void TaBortStudentRum()
            {

            }

            public List<StudentRum> StudentRum;


        }
    */

    public class Byggnad
    {
        // === 1. Attribut (Data) från DCD ===

        // ÅTGÄRD 1: Ge standardvärden till alla non-nullable strings
        public string Namn { get; set; } = string.Empty;
        public string GatuNummer { get; set; } = string.Empty;
        public int AntalRum { get; set; } // int är en value type, kräver ingen ? eller standardvärde.
        public string Status { get; set; } = "Tillgänglig"; // Sätter ett standardvärde


        // === 2. Relations-Property ===
        // RumLista är redan fixad med en initialisering: = new List<StudentRum>();

        public List<StudentRum> RumLista { get; set; } = new List<StudentRum>();


        // === 3. Konstruktorer ===

        // Primär konstruktor. (Denna är redan perfekt)
        public Byggnad(string namn, string gatuNummer, int antalRum, string status = "Tillgänglig")
        {
            this.Namn = namn;
            this.GatuNummer = gatuNummer;
            this.AntalRum = antalRum;
            this.Status = status;
        }

        // Standardkonstruktor. (Kan behållas nu när standardvärden är satta)
        public Byggnad() { }


        // === 4. Metoder (Operationer från DCD) ===

        // Metoder är oförändrade och korrekta.
        public void LäggTillStudentRum(StudentRum rum)
        {
            if (rum != null)
            {
                this.RumLista.Add(rum);
            }
        }

        public void UppdateraStudentRum(string rumID, string nyStatus)
        {
            var rum = RumLista.FirstOrDefault(r => r.RumID == rumID);
            if (rum != null)
            {
                rum.Status = nyStatus;
            }
        }

        public void TaBortStudentRum(string rumID)
        {
            this.RumLista.RemoveAll(r => r.RumID == rumID);
        }

        public List<Student> HämtaBoendeStudenter()
        {
            return new List<Student>();
        }
    }
}
