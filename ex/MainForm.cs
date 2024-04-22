using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testpaw1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ingredienteDataGridView.AutoGenerateColumns = true;
            ingredienteDataGridView.DataSource = BazaDeDateIngrediente.ingrediente;

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SecondForm frm = new SecondForm();
            frm.ShowDialog();
        }

        private void informatiiButon_Click(object sender, EventArgs e)
        {
            int sumaGrame = 0;
            foreach(Ingredient ingredient in BazaDeDateIngrediente.ingrediente) 
            { 
                if(ingredient.Nume.Equals("faina", StringComparison.OrdinalIgnoreCase))
                {
                    sumaGrame += ingredient.Grame;
                }
            }
            if(sumaGrame == 0)
            {
                MessageBox.Show("Nu exista ingredientul faina!");
            }
            else
            {
                MessageBox.Show($"Aveti nevoie de {sumaGrame} grame de faina!");
            }
        }

        private void serializareButon_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Alege fisierul (*.bin)|*.bin";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, BazaDeDateIngrediente.ingrediente);
                }
                MessageBox.Show("Serializare efectuata cu succes!");
            }
        }
    }
}
