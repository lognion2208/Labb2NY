using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{

    /*
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
    */

    ///////////////////////////////////////////////////////////////

    public class Student : Användare
    {
        // === 1. Relations-Properties (Unika för Student) ===

        // ENDAST EN DEKLARATION BEHÅLLS:
        // Markerad som nullable (BoendeKontrakt?) eftersom studenten KAN sakna kontrakt.
        public BoendeKontrakt? AktivtKontrakt { get; set; }

        // Initialiseras till en tom lista för att undvika Null-varningar.
        public List<Ansökan> Ansökningar { get; set; } = new List<Ansökan>();

        // RADEN HAR TAGITS BORT HÄR: public BoendeKontrakt AktivtKontrakt { get; set; }

        // === 2. Konstruktor ===

        // Korrigerat anrop till bas-klassen: skickar 4 argument.
        public Student(string namn, string epost, string lösenord, string personnummer)
            : base(namn, epost, lösenord, personnummer) // ANROPAR BASKLASSEN MED 4 ARGUMENT
        {
            // Inga andra fält behöver initialiseras här.
        }

        // Standardkonstruktor.
        public Student() { }


        // === 3. Metoder ===

        public void SkapaÄrende()
        {
            Console.WriteLine($"Ärende skapat för student {this.Namn}.");
        }

        public void SkickaAnsökan(BoBoKontroll kontroll, StudentRum rum)
        {
            var nyAnsökan = kontroll.SkickaAnsökan(this, rum.RumID);

            if (nyAnsökan != null)
            {
                this.Ansökningar.Add(nyAnsökan);
            }
        }

        // Använd new-modifiern för att dölja basklassens tomma metod.
        public new void RegistreraKonto(BoBoKontroll kontroll)
        {
            kontroll.RegistreraKonto(this);
        }

        // Dölj basklassens metod.
        public new void LoggaIn()
        {
            // Logik är i BoBoKontroll.
        }

        // Åtgärdat: Returtyp ändrad till Ansökan (som BoBoKontroll returnerar).
        public Ansökan? SeAnsökanStatus(BoBoKontroll kontroll)
        {
            return kontroll.SeAnsökanStatus(this);
        }
    }

}