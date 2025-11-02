using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    public class BoendeKontrakt
    {
        // Kopplingar till andra objekt (relationer 1..1)

        // ÅTGÄRD 1: Gör egenskapen Nullable med '?'
        // Löser varningen för 'Student'.
        public Student? Student { get; set; }

        // ÅTGÄRD 2: Gör egenskapen Nullable med '?'
        // Löser varningen för 'Rum'.
        public StudentRum? Rum { get; set; }

        // Kontraktsdata
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }

        // KontraktsID är redan fixat med ett standardvärde (Guid.NewGuid().ToString())

        public string KontraktsID { get; set; } = Guid.NewGuid().ToString();

        // Konstruktor som sätter alla värden. (Denna är perfekt som den är)
        public BoendeKontrakt(Student student, StudentRum rum, DateTime start, DateTime slut)
        {
            this.Student = student;
            this.Rum = rum;
            this.StartDatum = start;
            this.SlutDatum = slut;
        }

        // Standardkonstruktor.
        public BoendeKontrakt() { }
    }

    /*
    public class BoendeKontrakt
    {
        private 

        

        public Student Student; // Referens till studenten som har kontraktet
        public StudentRum StudentRum; // Referens till studentrummet som kontraktet gäller för

        public DateTime KontraktsStart { get; set; } 
        public DateTime KontraktsSlut { get; set; }

        public BoendeKontrakt(Student student, StudentRum rum, DateTime start, DateTime slut)
        {   //konstrutkor
            Student = student;
            StudentRum = rum;
            KontraktsStart = start;
            KontraktsSlut = slut;
        }

        


        
    }

    */


} 
