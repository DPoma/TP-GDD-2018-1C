﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class VentanaRegistrarIngreso : VentanaBase
    {
        public string numeroReserva { get; set; }

        public VentanaRegistrarIngreso(string numeroReserva)
        {
            InitializeComponent();
            this.numeroReserva = numeroReserva;
        }

        private void VentanaRegistrarIngreso_Load(object sender, EventArgs e)
        {

        }
    }
}
