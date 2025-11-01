using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
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
} 
