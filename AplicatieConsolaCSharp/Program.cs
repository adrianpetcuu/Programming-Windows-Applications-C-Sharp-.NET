using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConsolaCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //instantierea casei de bilete 0 bilete disponibile, 0 clienti in asteptare
            CasaDeBilete casaDeBilete = new CasaDeBilete();
            Console.WriteLine(casaDeBilete);

            //instantierea clientiilor (15 clienti) pentru a vedea care clienti sunt notificati 
            //atunci cand numarul clientiilor in asteptare pentru fiecare categorie ajunge la 5 
            Client client1 = new Client("Adrian");
            Client client2 = new Client("Andrei");
            Client client3 = new Client("Maria");
            Client client4 = new Client("Andreea");
            Client client5 = new Client("Alexandra");
            Client client6 = new Client("Mihai");
            Client client7 = new Client("Teodor");
            Client client8 = new Client("George");
            Client client9 = new Client("Ana");
            Client client10 = new Client("Alexia");
            Client client11 = new Client("Cristina");
            Client client12 = new Client("Nicolae");
            Client client13 = new Client("Lucas");
            Client client14 = new Client("Victor");
            Client client15 = new Client("Denisa");

            //abonare la eveniment pentru a notifica clientii
            casaDeBilete.NotificareClienti += (categorie, nrBilete) =>
            {
                Console.WriteLine("Au fost suplimentate {0} bilete la categoria {1}.", nrBilete, categorie);
                foreach (Client client in casaDeBilete.clientiInAsteptare[categorie])
                {
                    Console.WriteLine("Notificare: {0} - S-au suplimentat biletele pentru categoria {1}.", client, categorie);
                }
            };

            //vanzarea biletelor
            casaDeBilete.vanzareBilete(client1, Categorie.GeneralAcces, 1);
            casaDeBilete.vanzareBilete(client2, Categorie.GeneralAcces, 3);
            casaDeBilete.vanzareBilete(client3, Categorie.GeneralAcces, 4);
            casaDeBilete.vanzareBilete(client4, Categorie.GeneralAcces, 2);
            casaDeBilete.vanzareBilete(client6, Categorie.VipAcces, 4);
            casaDeBilete.vanzareBilete(client7, Categorie.VipAcces, 9);
            casaDeBilete.vanzareBilete(client8, Categorie.VipAcces, 7);
            casaDeBilete.vanzareBilete(client9, Categorie.VipAcces, 3);
            casaDeBilete.vanzareBilete(client11, Categorie.BackstageAcces, 6);
            casaDeBilete.vanzareBilete(client12, Categorie.BackstageAcces, 2);
            casaDeBilete.vanzareBilete(client13, Categorie.BackstageAcces, 5);
            casaDeBilete.vanzareBilete(client14, Categorie.BackstageAcces, 7);
            
            //starea casei de bilete cu 4 clienti in asteptare pentru fiecare categorie 
            Console.WriteLine(casaDeBilete);  

            //cand al 5-lea client doreste bilet si nu se efectueaza tranzactia => 0 clienti in asteptare, coada golita
            //si numarul biletelor este suplimentat cu 10 bilete pentru categoria respectiva  
            casaDeBilete.vanzareBilete(client5, Categorie.GeneralAcces, 3);
            Console.WriteLine(casaDeBilete);
            casaDeBilete.vanzareBilete(client10, Categorie.VipAcces, 4);
            Console.WriteLine(casaDeBilete);
            casaDeBilete.vanzareBilete(client15, Categorie.BackstageAcces, 5);
            Console.WriteLine(casaDeBilete);
            
            Console.ReadKey();

        }
    }
}
