using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConsolaCSharp
{
    public enum Categorie
    {
        GeneralAcces,
        VipAcces,
        BackstageAcces
    }

    public enum StatusTranzactie
    {
        TranzactieFinalizata,
        TranzactieNereusita
    }
    public class CasaDeBilete
    {
        //delegatul pentru notificarea clientilor atunci cand se suplimenteaza biletele pentru o categorie
        public delegate void NotificareClientiHandler(Categorie categorie, int numarBilete);
        //evenimentul pentru a declansa notificarile catre clientii respectivi
        public event NotificareClientiHandler NotificareClienti;


        //atribut pentru a retine biletele disponibile pentru fiecare categorie, cheia fiind categoria
        public Dictionary<Categorie, int> bileteDisponibile;
        //atribut pentru a retine clientii in asteptare intr-o coada pentru fiecare categorie, cheia fiind categoria
        public Dictionary<Categorie, Queue<Client>> clientiInAsteptare;

        //constructor care initializeaza casa de bilete cu 0 bilete disponibile si 0 clienti in asteptare
        public CasaDeBilete()
        {
            clientiInAsteptare = new Dictionary<Categorie, Queue<Client>>();
            bileteDisponibile = new Dictionary<Categorie, int>();

            //initializare cu 0 pentru biletele disponibile per categorie
            bileteDisponibile[Categorie.GeneralAcces] = 0;
            bileteDisponibile[Categorie.VipAcces] = 0;
            bileteDisponibile[Categorie.BackstageAcces] = 0;

            //creare coada goala pentru clientii in asteptare per categorie
            clientiInAsteptare[Categorie.GeneralAcces] = new Queue<Client>();
            clientiInAsteptare[Categorie.VipAcces] = new Queue<Client>();
            clientiInAsteptare[Categorie.BackstageAcces] = new Queue<Client>();
        }

        //metoda ToString() pentru a afisa situatia generala a casei de bilete
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Stare casa de bilete:\n");
            //itereaza prin fiecare categorie de bilete
            foreach (Categorie categorie in bileteDisponibile.Keys)
            {
                sb.Append(categorie);
                sb.Append(": ");
                sb.Append(bileteDisponibile[categorie]);
                sb.Append(" bilete disponibile, ");
                //verific daca exista clienti in asteptare pentru categoria curenta
                if (clientiInAsteptare.ContainsKey(categorie))
                {
                    //daca exista adaug numarul clientilor in asteptare
                    sb.Append(clientiInAsteptare[categorie].Count);
                    sb.Append(" client");
                }
                //daca numarul clientilor in asteptare este 0, 2, 3 sau 4 adauga "i" la finalul cuvantului "client"
                if (clientiInAsteptare[categorie].Count != 1)
                {
                    sb.Append("i");
                }
                sb.Append(" in asteptare.");
                sb.Append("\n");
            }
            return sb.ToString();
        }

        //functie care creste numarul de bilete disponibile la o anumita categorie cu un anumit numar
        public void suplimenteazaBilete(Categorie categorie, int nrBilete)
        {
            if (bileteDisponibile.ContainsKey(categorie))
            {
                bileteDisponibile[categorie] += nrBilete;
                //Console.WriteLine("S-au suplimentat {0} bilete la categoria {1}.", nrBilete, categorie);
                //declansarea evenimentului cand biletele sunt suplimentate
                NotificareClienti?.Invoke(categorie, nrBilete);
            }
            else
            {
                Console.WriteLine("Nu exista aceasta categorie.");
            }
        }

        //functie care se ocupa de vanzarea biletele catre clienti la o anumita categori 
        public StatusTranzactie vanzareBilete(Client client, Categorie categorie, int nrBilete)
        {
            //daca exista bilete disponibile la categoria respectiva si numarul lor este mai mare sau egal 
            //decat numarul de bilete cerute de client se efectueaza cu succes tranzactia
            if(bileteDisponibile.ContainsKey(categorie) && bileteDisponibile[categorie] >= nrBilete)
            {
                bileteDisponibile[categorie] -= nrBilete;
                Console.WriteLine("Tranzactie finalizata pentru {0}: {1} bilete la categoria {2}.", client, nrBilete, categorie);
                return StatusTranzactie.TranzactieFinalizata;
            }
            //in cazul in care bilete disponibile la categoria respectiva sunt prea putine clientul este introdus intr-o
            //coada de asteptare pentru a fi notificat atunci cand numarul biletelor la categoria respectiva este suplimentat
            else
            {
                //client introdus in coada
                clientiInAsteptare[categorie].Enqueue(client);
                Console.WriteLine("Tranzactie nereusita pentru {0}: nu sunt suficiente bilete disponibile la categoria {1}.", client, categorie);
                //daca clientii in asteptare sunt 5 , biletele la categoria respectiva sunt suplimentate si coada este golita
                if (clientiInAsteptare[categorie].Count == 5)
                {
                    suplimenteazaBilete(categorie, 10);
                    clientiInAsteptare[categorie].Clear(); 
                }
                return StatusTranzactie.TranzactieNereusita;
            }
        }
    }
}
