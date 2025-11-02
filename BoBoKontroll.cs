using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{

    /*
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

    */
    public class BoBoKontroll
    {
        // === 1. Datalagring (Systemets "databas") ===
        private List<Användare> _användareLista = new List<Användare>();
        private List<Byggnad> _byggnadLista = new List<Byggnad>();
        private List<Ansökan> _ansökanLista = new List<Ansökan>();

        // === 2. Initiering och Testdata ===
        public void InitieraTestdata()
        {
            // Administratör
            var admin1 = new Administratör("Anna Admin", "admin@bobo.se", "hemligt123", "700101-1234");
            _användareLista.Add(admin1);

            // Byggnad och Rum
            var byggnadA = new Byggnad("Campus Solna", "Solnavägen 10", 3);
            // OBS! Se till att StudentRum har en konstruktor som hanterar Status korrekt för att undvika Null-varningar.
            var rum101 = new StudentRum("101", "Enkelrum");
            var rum202 = new StudentRum("202", "Delat Rum");
            byggnadA.LäggTillStudentRum(rum101);
            byggnadA.LäggTillStudentRum(rum202);
            _byggnadLista.Add(byggnadA);

            // Student och Ansökan (som testdata)
            var studentLisa = new Student("Lisa Student", "lisa@student.se", "pass123", "950505-5555");
            _användareLista.Add(studentLisa);
            // OBS! Se till att Ansökan har en property 'Datum' för att SeAnsökanStatus ska fungera optimalt.
            var ansokanLisa = new Ansökan(studentLisa, rum202);
            _ansökanLista.Add(ansokanLisa); // Lisa har en ansökan med status "Ny"
        }

        // === 3. Användarhantering ===
        public void RegistreraKonto(Användare nyAnvändare)
        {
            if (!_användareLista.Any(u => u.Epost == nyAnvändare.Epost))
            {
                _användareLista.Add(nyAnvändare);
            }
        }

        public Användare LoggaIn(string epost, string lösenord)
        {
            return _användareLista.FirstOrDefault(u => u.Epost == epost && u.Lösenord == lösenord);
        }

        // NY METOD: Tar bort en användare (anropas från Admin-gränssnittet)
        public void TaBortAnvändare(string epost)
        {
            var användare = _användareLista.FirstOrDefault(u => u.Epost == epost);
            if (användare != null)
            {
                _användareLista.Remove(användare);
            }
        }

        // NY METOD: Ändrar information för en användare (anropas från Admin-gränssnittet)
        public void ÄndraAnvändare(Användare uppdateradAnvändare)
        {
            var befintligAnvändare = _användareLista.FirstOrDefault(u => u.Epost == uppdateradAnvändare.Epost);
            if (befintligAnvändare != null)
            {
                befintligAnvändare.Namn = uppdateradAnvändare.Namn;
                befintligAnvändare.Lösenord = uppdateradAnvändare.Lösenord;
                // Lägg till andra fält som ska kunna ändras
            }
        }

        // === 4. Studentens Ansökningslogik ===
        public List<StudentRum> HämtaLedigaRum()
        {
            var ledigaRum = new List<StudentRum>();
            foreach (var byggnad in _byggnadLista)
            {
                ledigaRum.AddRange(byggnad.RumLista.Where(r => r.Status == "Ledig"));
            }
            return ledigaRum;
        }

        public Ansökan SkickaAnsökan(Student student, string rumId)
        {
            StudentRum valtRum = HittaRumViaID(rumId);

            if (valtRum != null && valtRum.Status == "Ledig")
            {
                var nyAnsökan = new Ansökan(student, valtRum);
                _ansökanLista.Add(nyAnsökan);
                return nyAnsökan;
            }
            return null;
        }

        // NY METOD: Hämtar en students ansökningsstatus (anropas från StudentForm)
        public Ansökan SeAnsökanStatus(Student student)
        {
            // Returnerar den senast skapade ansökan för den studenten.
            return _ansökanLista
                       .Where(a => a.AnsökandeStudent == student)
                       // OrderByDescending(a => a.Datum) är bäst, men Status fungerar också om Datum saknas
                       .OrderByDescending(a => a.Status)
                       .FirstOrDefault();
        }


        // === 5. Administrativ Hantering (Ansökan och Rum) ===

        // NY METOD: Hämta nya ansökningar för Admin 
        public List<Ansökan> HämtaNyaAnsökningar()
        {
            // Hämtar alla ansökningar som har status "Ny"
            return _ansökanLista.Where(a => a.Status == "Ny").ToList();
        }

        public void HanteraAnsökan(Ansökan ansökan, bool godkänn)
        {
            // Steg 1: Ta bort ansökan från listan direkt (den är hanterad)
            _ansökanLista.Remove(ansökan);

            if (godkänn)
            {
                // 1. Kontrollera status igen (detta är säkerhet)
                if (ansökan.RumIntresse.Status != "Ledig")
                {
                    // Om rummet precis blev upptaget av någon annan
                    ansökan.Status = "Misslyckad - Rum upptaget";
                    // Kanske vill du lägga till den i en misslyckad-lista här, men för nu, returnera.
                    return;
                }

                // 2. SKAPA KONTRAKTET
                // Vi antar att BoendeKontrakt-klassen har en konstruktor som tar dessa argument.
                var nyttKontrakt = new BoendeKontrakt(
                    ansökan.AnsökandeStudent,
                    ansökan.RumIntresse,
                    DateTime.Today,
                    DateTime.Today.AddYears(1)); // Kontraktslängd: 1 år

                // 3. KOPPLA KONTRAKTET TILL STUDENT & RUM

                // a) Koppla till Studenten
                // OBS: Detta kräver att Student-klassen har en egenskap: public BoendeKontrakt AktivtKontrakt { get; set; }
                ansökan.AnsökandeStudent.AktivtKontrakt = nyttKontrakt;

                // b) Koppla till Rummet
                // OBS: Detta kräver att StudentRum-klassen har en egenskap: public BoendeKontrakt AktivtKontrakt { get; set; }
                ansökan.RumIntresse.AktivtKontrakt = nyttKontrakt;

                // 4. UPPDATERA STATUS

                // Sätt rummets status till Uthyrd (använd statusvärdet vi enades om, Uthyrd/Ledig)
                // OBS: Detta kräver att StudentRum-klassen har en metod/egenskap för att ändra Status.
                ansökan.RumIntresse.Status = "Uthyrd";

                ansökan.Status = "Godkänd";
            }
            else
            {
                // Nekad logik
                ansökan.Status = "Nekad";
                // OBS: Om du vill behålla nekade ansökningar för historik, behöver du en separat lista.
            }
        }
        

        // NY METOD: Lägg till rum (anropas av AdminForm.cs)
        public void LäggTillRum(Byggnad byggnad, StudentRum nyttRum)
        {
            // Vi lägger till rummet i Byggnads RumLista direkt
            byggnad.LäggTillStudentRum(nyttRum);
        }

        // NY METOD: Ta bort rum (anropas av AdminForm.cs)
        public void TaBortRum(string rumId)
        {
            foreach (var byggnad in _byggnadLista)
            {
                var rumToRemove = byggnad.RumLista.FirstOrDefault(r => r.RumID == rumId);
                if (rumToRemove != null)
                {
                    byggnad.RumLista.Remove(rumToRemove);
                    return;
                }
            }
        }

        // NY METOD: Uppdatera rumstatus (anropas av AdminForm.cs)
        public void UppdateraRumStatus(string rumId, string nyStatus)
        {
            StudentRum rumToUpdate = HittaRumViaID(rumId);

            if (rumToUpdate != null)
            {
                rumToUpdate.UppdateraStatus(nyStatus);
            }
        }
        public void UppdateraRumstyp(string rumID, string nyRumstyp)
        {
            // Steg 1: Hitta rummet
            StudentRum rum = HittaRumViaID(rumID);

            if (rum != null)
            {
                // Steg 2: Uppdatera egenskapen
                rum.Rumstyp = nyRumstyp;
                // Om du har en sparlogik till fil/databas, lägg till den här
            }
            else
            {
                // Felhantering om rummet inte hittades
                throw new ArgumentException($"Rum med ID {rumID} hittades inte.");
            }
        }


        // === 6. Hjälpfunktioner för Dataåtkomst (Anropas av GUI) ===

        // NY METOD: Hämtar alla StudentRum i hela systemet.
        public List<StudentRum> HämtaAllaRumISystemet()
        {
            return _byggnadLista
                .SelectMany(b => b.RumLista) // Platta ut listan av rum från alla byggnader
                .ToList();
        }

        // NY METOD: Hämtar en specifik Byggnad via dess namn.
        public Byggnad HämtaByggnadViaNamn(string namn)
        {
            return _byggnadLista.FirstOrDefault(b => b.Namn == namn);
        }

        // Ursprunglig Privat Hjälpfunktion
        private StudentRum HittaRumViaID(string rumId)
        {
            return _byggnadLista
                .SelectMany(b => b.RumLista)
                .FirstOrDefault(r => r.RumID == rumId);
        }
    }

}
