using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Aministratör : Användare //ARVET
    {   
        public void LäggaTillAnvändare() { }
        public void TaBortAnvändare() { }
        public void ÄndraAnvändare() { }

        public List<Användare> Användare;
    }
}
