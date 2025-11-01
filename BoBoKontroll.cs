using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BoBoKontroll
    {
        public void Testdata()
        {
            Byggnad byggnad1 = new Byggnad()
            {
                Namn = "Campushemmet",
                Gatunummer = 12,
                Status = "Tillgängligt"
            };

            Student student1 = new Student()
            {
                Namn = "Anna Svensson",
                Personnummer = "19950101-1234",

            };

            Administratör admin = new Administratör()
            {


            };


        }
        public void Registrerakonto()
        {
        
        }


        public void hanteraAnsökan() { }
        public void seAnsökanStatus() { }
        public void godkännAnsökan() { }
    }
}
