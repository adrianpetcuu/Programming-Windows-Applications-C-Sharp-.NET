
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testpaw1
{
    [Serializable]
    public class Ingredient
    {
        public string Nume { get; set; }
        public int Grame { get; set; }
        public bool EsteIngredientUscat { get; set; }
        public double Uncii
        {
            get
            {
                return Grame * 0.0352;
            }
        }
    }
}
