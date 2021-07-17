using AlienspaceBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alienspace.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var peliculasBL = new PeliculasBL();
            var listadePeliculas = peliculasBL.ObtenerPeliculas();
            listadePeliculasBindingSource.DataSource = listadePeliculas;
        }
    
        // Not touch
        private void listadePeliculasBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
