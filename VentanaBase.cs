﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class VentanaBase : Form
    {

        protected string ProgramTitle { get; set; }

        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        private void VentanaBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static bool camposEstanCompletos(Control ventana, ErrorProvider errorProvider)
        {
            bool flagControl = true;
            foreach (Control objeto in ventana.Controls)
            {
                if(objeto is TextBox)
                {
                    TextBox textBox = (TextBox)objeto;
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        flagControl = false;
                        errorProvider.SetError(textBox, "El campo no puede estar vacio");
                    }
                    else
                        errorProvider.SetError(textBox, "");
                }
                if(objeto is ListBox)
                {
                    ListBox listBox = (ListBox)objeto;
                    if (listBox.Items.Count == 0)
                    {
                        flagControl = false;
                        errorProvider.SetError(listBox, "Debe seleccionar al menos una opcion");
                    }
                    else
                        errorProvider.SetError(listBox, "");
                }
            }
            return flagControl;
        }

        public static void informarCamposIncompletos()
        {
            MessageBox.Show("Todos los campos deben estar completos");
        }

    }
}
