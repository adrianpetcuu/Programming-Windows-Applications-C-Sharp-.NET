using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testpaw1
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Nume = numeTb.Text;
            ingredient.Grame = Convert.ToInt32(grameTb.Text);
            ingredient.EsteIngredientUscat = esteUscatCb.Checked;
            BazaDeDateIngrediente.ingrediente.Add(ingredient);
            Close();
        }
    }
}
