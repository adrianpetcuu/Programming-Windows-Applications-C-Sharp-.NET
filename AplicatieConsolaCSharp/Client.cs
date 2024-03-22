using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConsolaCSharp
{
    public class Client
    {
        private string name;
        //readonly utilizat pentru a face id-ul imutabil, sa nu poata fi modificat, doar in constructor 
        private readonly int id;
        //static pentru a retine ultimul id creat, specific clasei per total
        private static int ultimulIdCreat = 0;
       
        //constructor pentru a crea clienti, chiar daca numele este acelasi,
        //id ul sa fie unic incrementat la fiecare client nou creat
        public Client(string Name)  
        {
            this.name = Name;
            this.id = ++ultimulIdCreat; 
        }

        //metoda ToString() pentru a afisa numele si id-ul clientului
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Clientul ");
            sb.Append(this.name);
            sb.Append(" cu id-ul ");
            sb.Append(this.id);
            return sb.ToString();
        }

    }

}
