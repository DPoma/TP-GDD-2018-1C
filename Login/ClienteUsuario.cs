﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class ClienteUsuario : Form
    {
        public ClienteUsuario()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Re dirige a la pagina principal de acciones pero con rol de guest
        }
    }
}