using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ansökan
    {
        private DateTime Datum { get; }
        private DateTime Time { get; }
        private String Status;

        public StudentRum StudentRum;
        public Student Student;

    }
}
