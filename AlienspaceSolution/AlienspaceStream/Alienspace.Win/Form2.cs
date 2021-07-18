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
    public partial class Form2 : Form
    {
        ReportesPeliculasBL _ReportesPeliculasBL;

        public Form2()
        {
            InitializeComponent();
            _ReportesPeliculasBL = new ReportesPeliculasBL();
            RefreshDatas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDatas();
        }

        private void RefreshDatas()
        {
            var listaReportesPeliculas = _ReportesPeliculasBL.ObtenerReportesPeliculas();
            listaReportesPeliculasBindingSource.DataSource = listaReportesPeliculas;
            listaReportesPeliculasBindingSource.ResetBindings(false);
        }
    }
}
