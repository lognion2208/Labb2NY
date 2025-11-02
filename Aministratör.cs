using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    /*
    public class Aministratör : Användare //ARVET
    {   
        public void LäggaTillAnvändare() { }
        public void TaBortAnvändare() { }
        public void ÄndraAnvändare() { }

        public List<Användare> Användare;
    }
    */

    public class Administratör : Användare
    {
        // === 1. Konstruktor ===

        // Korrigerat anrop: Tar emot 4 argument och sätter status i konstruktorbody.
        public Administratör(string namn, string epost, string lösenord, string personnummer)
            : base(namn, epost, lösenord, personnummer) // Anropar basklassen med 4 argument
        {
            // Sätter Status-propertyn till "Admin" efter att bas-klassen har initialiserats.
            this.Status = "Admin";
        }

        // Standardkonstruktor.
        public Administratör() { }


        // === 2. Metoder (Operationer från DCD) ===

        public void LäggTillRum(BoBoKontroll kontroll, Byggnad byggnad, StudentRum rum)
        {
            kontroll.LäggTillRum(byggnad, rum);
        }

        public void RedigeraRumsinformation(BoBoKontroll kontroll, string rumId, string nyStatus)
        {
            kontroll.UppdateraRumStatus(rumId, nyStatus);
        }

        public void TaBortRum(BoBoKontroll kontroll, string rumId)
        {
            kontroll.TaBortRum(rumId);
        }

        public void GodkännNekaAnsökan(BoBoKontroll kontroll, Ansökan ansökan, bool godkänn)
        {
            kontroll.HanteraAnsökan(ansökan, godkänn);
        }

        // Metoder för användarhantering
        public void LäggTillAnvändare(BoBoKontroll kontroll, Användare nyAnvändare)
        {
            kontroll.RegistreraKonto(nyAnvändare);
        }

        public void TaBortAnvändare(BoBoKontroll kontroll, string epost)
        {
            kontroll.TaBortAnvändare(epost);
        }

        // KORRIGERAT: Ska skicka ett Användare-objekt, inte bara epost, för att matcha BoBoKontroll
        public void ÄndraAnvändare(BoBoKontroll kontroll, Användare uppdateradAnvändare)
        {
            kontroll.ÄndraAnvändare(uppdateradAnvändare);
        }
    }
}
