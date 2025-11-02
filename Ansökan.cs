using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    /*
    public class Ansökan
    {
        private DateTime Datum { get; }
        private DateTime Time { get; }
        private String Status;

        public StudentRum StudentRum;
        public Student Student;

    }
    */
    public class Ansökan
    {
        // === 1. Attribut (Data) ===

        public Guid AnsökanID { get; } = Guid.NewGuid();
        public DateTime Datum { get; set; }

        // ÅTGÄRD 1: Ge ett standardvärde direkt i egenskapen.
        // Detta löser varningen för 'Status'.
        public string Status { get; set; } = "Ny";

        public string StudentEpost
        {
            get
            {
                // ÅTGÄRD 3: Använd null-conditional operator (?) för att hantera null AnsökandeStudent
                return AnsökandeStudent?.Epost ?? string.Empty;
            }
        }


        // === 2. Relations-Properties ===

        // ÅTGÄRD 2: Gör egenskaperna nullable med '?'
        // Detta löser varningarna för 'AnsökandeStudent' och 'RumIntresse'.
        public Student? AnsökandeStudent { get; set; }

        public StudentRum? RumIntresse { get; set; }


        // === 3. Konstruktor ===

        // Denna konstruktor är redan perfekt och sätter alla värden.
        public Ansökan(Student student, StudentRum rum)
        {
            this.AnsökandeStudent = student;
            this.RumIntresse = rum;
            this.Datum = DateTime.Now;
            // this.Status = "Ny"; // Redan satt ovan, men kan behållas för tydlighet.
        }

        // Standardkonstruktor. Kan behållas om du behöver den för deserialisering/GUI.
        public Ansökan() { }
    }

}
