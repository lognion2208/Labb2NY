using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : Användare //ARVET 
    {
        public void SkickaÄrende() { }
        public void SkickaAnsökan() { }
        public void RegistreraKonto()
        {


        }
        public void loggaIn() { }


        public BoendeKontrakt Aktivtkontrakt; //en referens till kontraktet som studenten har
    }
}