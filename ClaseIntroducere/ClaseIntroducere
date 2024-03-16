using System;
using System.Collections.Generic;
using System.Text; 


namespace ClaseIntroducere
{
    //definire clasa abstracta 
    public abstract class Persoana
    {
        //campuri
        protected string cnp;
        protected string nume;

        //proprietati
        public string Cnp
        { 
            get { return cnp; } 
        }
        public string Nume
        {
            get { return nume; }
            set { if (value != null && !value.Equals("")) nume = value; }
        }

        //definire constructor cu parametrii
        public Persoana(string Cnp, string Nume)
        {
            this.cnp = Cnp;
            this.nume = Nume;
        }
        //definire metoda abstracta
        public abstract int SpuneVarsta();
    }

    //definire interfata IMedia
    public interface IMedia
    {
        double calculeazaMedia(double[] elem);
    }

    //definire clasa inchisa (sealed) 
    public sealed class Student : Persoana, ICloneable, IMedia, IDisposable
    {
        //atribut constant prin readonly
        private readonly int nrMatricol;
        //atribut constant prin const 
        private const char sex = 'F';
        //atribut static
        public static int anStudiu = 3;
        //vector de note 
        private double[] note;

        //definire constructor fara parametrii
        public Student():base("00000", "Anonim")
        {
            nrMatricol = 0;
            note = null;
        }
        //definire constructor cu parametrii
        public Student(string Cnp, string Nume, int NumarMatricol):base(Cnp, Nume)
        {
            nrMatricol = NumarMatricol;
            note = null;
        }
        ~Student()
        {
            Console.WriteLine("\nApel destructor!");
        }

        public void Dispose()
        {
            Console.WriteLine("\nApel dispose!");
            GC.SuppressFinalize(this);
        }

        //proprietati
        public int NrMatricol
        {
            get { return nrMatricol; }
        }

        public char Sex
        {
            //sunt accesate prin numele clasei
            get { return Student.sex; }
        }

        public double[] Note
        {
            get { return this.note; }
        }

        public int NrNote
        {
            get
            {
                if(note != null)
                {
                    return this.note.Length;
                }
                else
                {
                    return 0;
                }    
            }
        }

        //supraincarcare indexer
        public double this[int index]
        {
            get
            {
                if(note != null && index >= 0 && index < note.Length)
                {
                    return note[index];
                }
                else
                {
                    return -1;
                }
            }
        }

        //supradefinire metoda Clone() din IClonable
        public object Clone()
        {
            Student Nou = new Student(this.cnp, this.nume, this.nrMatricol);
            if(this.note != null)
            {
                Nou.note = (double[])this.note.Clone();
            }
            return Nou;
            //return (Student)((ICloneable)this).Clone();
            //return (ICloneable)this.Clone();
        }

        //public Student Clone()
        //{
        //    return (Student)((ICloneable)this).Clone();
        //}
        
        //object ICloneable.Clone()
        //{
        //    return this.MemberwiseClone();
        //}

       // implementare metoda din clasa abstracta
        public override int SpuneVarsta()
        {
            int anCurent = System.DateTime.Now.Year;
            string anNastere = this.cnp.Substring(1, 2);
            anNastere = "19" + anNastere;
            int varsta = anCurent - Int32.Parse(anNastere);
            return varsta;
        }

        public double calculeazaMedia(double[] elem)
        {
            double total = 0;
            if (elem != null)
            {
                for (int i = 0; i < elem.Length; i++)
                {
                    total += elem[i];
                }
            }
            
            return total / elem.Length;
        }

        public override string ToString()
        {
            if(this.note == null)
            {
                return "Studentul " + this.nume + " cu cnp " + this.cnp + " are 0 note";
            }
            else
            {
                return "Studentul " + this.nume + " cu cnp " + this.cnp + " are " + this.note.Length + " note";
            }
        }

        //supraincarcare operator + pentru a adauga o nota in vectorul de note
        public static Student operator +(Student s, double n)
        {
            Student copie = (Student)s.Clone();
            //Student copie = s.Clone();
            if(copie.note != null)
            {
                double[] noteNoi = new double[copie.note.Length + 1]; //se aloca memorie pentru vectorul nou de note
                copie.note.CopyTo(noteNoi, 0); //copieaza in vectorul noteNoi toate elementele din vectorul note incepand de la pozitia 0
                noteNoi[noteNoi.Length - 1] = n; //se adauga nota noua n pe ultima pozitie
                copie.note = noteNoi;
            }
            else
            {
                copie.note = new double[1];
                copie.note[0] = n;
            }
            return copie;
        }

        public static Student operator +(double n, Student s)
        {
            return s + n;
        }

        //supraincarcare operator ++
        public static Student operator ++(Student s)
        {
            s = s + 1;
            return s;
        }

        //supraincarcare operator cast la double pentru calcul medie
        public static explicit /*implicit*/ operator double(Student s)
        {
            double total = 0;
            if(s.note != null)
            {
                for(int i = 0; i < s.note.Length; i++)
                {
                    total += s.note[i];
                }
            }
            return total / s.note.Length;
        }

        //supraincarcare operator > 
        public static bool operator > (Student s1, Student s2)
        {
            if ((double)s1 > (double)s2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //supraincarcare operator <
        public static bool operator <(Student s1, Student s2)
        {
            if((double)s1 < (double)s2)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            /*using (s)
            {
                Console.WriteLine(s.ToString());
            }*/
            s.Dispose();

            Student s1 = new Student("1931934", "Maria", 123);
            Console.WriteLine(s1.ToString());
            s1 = s1 + 9.6;
            s1 = 9.5 + s1;
            s1 += 8.2;
            //Student.anStudiu = 5;

            //afisare note
            for (int i = 0; i < s1.Note.Length; i++)
            {
                Console.WriteLine("Nota {0} = {1}", i + 1, s1.Note[i]);
            }

            Console.WriteLine(s1.ToString());

            Console.WriteLine("Studentul {0} are varsta de {1} ani, sexul {2}, este in anul {3} si are " +
            "media {4}", s1.Nume, s1.SpuneVarsta(), s1.Sex, Student.anStudiu, (double)s1);

            //apel metoda Clone()
            Student s2 = (Student)s1.Clone();
            s2 += 10;
            
            for(int i = 0; i < s2.Note.Length; i++)
            {
                Console.WriteLine("Nota {0} = {1}", i + 1, s2.Note[i]);
            }
            //apel metoda din interfata IMedia
            Console.WriteLine("{0} are media {1}", s2, s2.calculeazaMedia(s2.Note));
            //operator > 
            Console.WriteLine("\nApel operator >");
            if(s2 > s1)
            {
                Console.WriteLine(s2);
            }
            else
            {
                Console.WriteLine(s1);
            }

            Console.WriteLine("\nApel operator ++");
            //post-fixat , intai atribuie si dupa se face incrementarea
            s2 = s1++;
            Console.WriteLine(s2);  
            //pre-fixat , intai se face incrementarea lui s1 dupa atribuirea
            s2 = ++s1;
            Console.WriteLine(s2);

            Console.WriteLine(s2[2]);

            s2.Nume = "Marius";
            Console.WriteLine(s2.Nume);

            //clasa abstracta nu se instantiaza
            //Persoana p = new Persoana("1234", "Adrian");

            Console.ReadLine();
        }
    }   
}
