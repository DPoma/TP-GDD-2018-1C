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
    public partial class VentanaInicio : VentanaBase
    {
        public VentanaInicio()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VentanaLogin().Show();
        }

        private void VentanaInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
