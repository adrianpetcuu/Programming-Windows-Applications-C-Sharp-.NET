using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace testpaw1
{
    public static class BazaDeDateIngrediente
    {
        public static BindingList<Ingredient> ingrediente = new BindingList<Ingredient>()
        {
            new Ingredient()
            {
                Nume = "faina",
                Grame = 30,
                EsteIngredientUscat = true
            },
            new Ingredient()
            {
                Nume = "apa",
                Grame = 100,
                EsteIngredientUscat = false
            }
        };
    }
}
